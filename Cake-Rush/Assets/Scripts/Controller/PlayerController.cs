using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitBase
{
    [SerializeField] private GameObject attackRangeView;
    [SerializeField] private GameObject cokeShotField;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private CokeShot cokeShot;
    [SerializeField] private Lightning lightning;
    [SerializeField] private ShootingStar shootingStart;

    Collider[] colliders;
    private Camera mainCamera;
    
    protected override void Awake()
    {
        mainCamera = Camera.main;
        DataLoad("Player"); 
        
        base.Awake();
        navMashAgent.speed = moveSpeed;
    }

    protected override void Attack(Transform target)
    {
        state = CharacterState.Attack;

        navMashAgent.isStopped = true;

        animator.SetBool("Move", false);
        animator.SetBool("Attack", true);

        target.GetComponent<EntityBase>().Hit(damage);
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKey(KeyCode.Q))             //낙뢰
        {
            Lightning();
        }
        else if(Input.GetKey(KeyCode.W))        //콜라 뿌리기
        {
            CokeShot();
        }
        else if(Input.GetKey(KeyCode.E))        //슈팅 스타
        {
            ShootingStar();
        }
        else if(Input.GetKeyDown(KeyCode.R))        //케이크 러쉬
        {
            CakeRush();
        }
    }

    private void Lightning()
    {

    }

    private void CokeShot()
    {
        
    }

    private void ShootingStar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(colliders.Length > 0)
            {
                for(int i = 0; i < colliders.Length; i++)
                {
                    colliders[i] = null;
                }
            }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(hit.point - transform.position), 90);

                colliders = Physics.OverlapSphere(transform.position, 5.0f, 1 << LayerMask.NameToLayer("Selectable"));
                
                shootingStart.UseSkill(shootingStart.skillLevel, colliders);
                Debug.DrawRay(Camera.main.transform.position, hit.point, Color.blue, 1f);
            }

        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, 3.0f);
    //}

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.skillLevel);
    }

    private IEnumerator Build(bool onBuild)     //건물 건설
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        while(onBuild)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
                {
                    Debug.Log($"Build as {hit.point}");
                    break;
                }
            }

            yield return null;
        }
        
        Debug.Log("end");
    }
}