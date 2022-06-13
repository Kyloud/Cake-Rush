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

        cakeRush = GetComponent<CakeRush>();
        shootingStar = GetComponent<ShootingStar>();
        lightning = GetComponent<Lightning>();
        cokeShot = GetComponent<CokeShot>();

        base.Awake();
        SkillInit();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.Q))             //Lightning
        {
            StartCoroutine(Lightning());
        }
        else if (Input.GetKey(KeyCode.W))        //Coke shot
        {
            StartCoroutine(CokeShot());
        }
        else if (Input.GetKey(KeyCode.E))        //Shooting star
        {
            ShootingStar();
        }
        else if (Input.GetKeyDown(KeyCode.R))        //Cake rush
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
        cakeRush.level = 0;
        cokeShot.level = 0;
        lightning.level = 0;
        shootingStar.level = 0;

        lightning.range = 10f;
        cokeShot.range = 5f;
    }

    private IEnumerator Lightning()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.selectableLayer))
            {
                while (lightning.range < (hit.transform.position - transform.position).sqrMagnitude)
                {
                    base.Move(hit.transform.position);
                    yield return null;
                }

                navMashAgent.Stop();
                animator.SetBool("Move", false);
                lightning.UseSkill(lightning.level);
            }
        }
    }

    private IEnumerator CokeShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.groundLayer))
            {
                while (cokeShot.range < (hit.transform.position - transform.position).sqrMagnitude)
                {
                    base.Move(hit.transform.position);
                    yield return null;
                }
                Collider[] colliders = Physics.OverlapSphere(hit.point, 5f);

                navMashAgent.Stop();
                animator.SetBool("Move", false);
                cokeShot.UseSkill(cokeShot.level, colliders);
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

                shootingStar.UseSkill(shootingStar.level, colliders);
                Debug.DrawRay(Camera.main.transform.position, hit.point, Color.blue, 1f);
            }
        }
    }

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.level);
    }

    private IEnumerator Build(bool onBuild)     //건물 건설
    {
        Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        while (onBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.groundLayer))
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