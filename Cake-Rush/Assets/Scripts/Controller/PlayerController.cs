using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitBase
{
    private CokeShot cokeShot;
    private Lightning lightning;
    private ShootingStar shootingStar;
    
    protected override void Awake()
    {
        DataLoad("Player");

        base.Awake();

        cakeRush = GetComponent<CakeRush>();
        shootingStar = GetComponent<ShootingStar>();
        lightning = GetComponent<Lightning>();
        cokeShot = GetComponent<CokeShot>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKey(KeyCode.Q))             //낙뢰
        {
            StartCoroutine(Lightning());
        }
        else if(Input.GetKey(KeyCode.W))        //콜라 뿌리기
        {
            StartCoroutine(CokeShot());
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

    protected override void Attack(Transform target)
    {
        state = CharacterState.Attack;

        navMashAgent.isStopped = true;

        animator.SetBool("Move", false);
        animator.SetBool("Attack", true);

        target.GetComponent<EntityBase>().Hit(damage);
    }

    private void SkillInit()
    {
        cakeRush.skillLevel = 0;
        cokeShot.skillLevel = 0;
        lightning.skillLevel = 0;
        shootingStar.skillLevel = 0;

        lightning.range = 10f;
        
    }

    private IEnumerator Lightning()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.selectableLayer))
            {
                while (lightning.range < (hit.transform.position - transform.position).sqrMagnitude)
                {
                    base.Move(hit.transform.position);
                    yield return null;
                }

                navMashAgent.Stop();
                animator.SetBool("Move", false);
                lightning.UseSkill(lightning.skillLevel);
            }
        }
    }

    private IEnumerator CokeShot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.groundLayer))
            {
                while (cokeShot.range < (hit.transform.position - transform.position).sqrMagnitude)
                {
                    base.Move(hit.transform.position);
                    yield return null;
                }

                navMashAgent.Stop();
                animator.SetBool("Move", false);
                cokeShot.UseSkill(cokeShot.skillLevel);
            }
        }
    }

    private void ShootingStar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(hit.point - transform.position), 90);

                Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0f, GameProgress.instance.selectableLayer);
                
                shootingStar.UseSkill(shootingStar.skillLevel, colliders);         
                Debug.DrawRay(Camera.main.transform.position, hit.point, Color.blue, 1f);
            }
        }
    }

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.skillLevel);
    }

    private IEnumerator Build(bool onBuild)     //건물 건설
    {
        Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        while(onBuild)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.groundLayer))
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