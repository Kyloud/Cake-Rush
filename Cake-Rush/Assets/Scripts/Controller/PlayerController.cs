using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitBase
{
    [SerializeField] private GameObject attackRangeView;
    [SerializeField] private GameObject cokeShotField;
    [SerializeField] private LayerMask groundLayer;

    private Camera mainCamera;
    private CokeShot cokeShot;
    
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

        if(Input.GetKeyDown(KeyCode.R))
        {
            CakeRush();
        }

        var direction = Quaternion.AngleAxis(1, transform.right) * transform.forward;

        Ray ray = new Ray(transform.position, direction);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 5, Color.red);
    }

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.skillLevel);
        Debug.Log("Cake Rush");
    }

    private void CokeShot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, attackRange, groundLayer))
            {
                cokeShot.UseSkill(cokeShot.skillLevel);
                cokeShotField.SetActive(true);
            }
        }
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