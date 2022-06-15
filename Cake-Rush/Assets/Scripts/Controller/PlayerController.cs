using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitBase
{
    private CokeShot cokeShot;
    private Lightning lightning;
    private ShootingStar shootingStar;
    //private Build build;

    [SerializeField] GameObject cookieHouse;
    
    protected override void Awake()
    {
        DataLoad("Player");

        cakeRush = GetComponent<CakeRush>();
        shootingStar = GetComponent<ShootingStar>();
        lightning = GetComponent<Lightning>();
        cokeShot = GetComponent<CokeShot>();
        //build = GetComponent<Build>();
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
        else if(Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(Build());
        }
    }

    protected override void Attack (Transform target)
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

        shootingStar.range = 6f;
        lightning.range = 10f;
        cokeShot.range = 30f;
        cokeShot.radius = 5f;
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
                while (cokeShot.range < (hit.point - transform.position).sqrMagnitude)
                {
                    base.Move(hit.point);
                    yield return null;
                }

                navMashAgent.Stop();
                animator.SetBool("Move", false);
                cokeShot.UseSkill(cokeShot.level, hit.point);
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

    private IEnumerator Build()
    {
        Debug.Log("BuildMode");
        GameObject go = null;
        RaycastHit hit;
        BuildBase build = null;
        string curBuildName = null;

        yield return null;
        
        while(true)
        {
            if(go != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 5000f, LayerMask.NameToLayer("selectable")))
                {
                    go.transform.position = hit.point;
                }
                if(Input.GetMouseButtonDown(0) && ((hit.point) - transform.position).magnitude < 5f)
                {
                    StartCoroutine(build.Build());
                    go = null;
                    Debug.Log("Build!");
                    curBuildName = null;
                    break;
                }
            }
            
            //Input
            if(go == null)
            {
                if(Input.GetKeyDown(KeyCode.U) && curBuildName != cakeRush.name)
                {
                    Debug.Log($"Select {cookieHouse.name} {cakeRush.name}");
                    go = Instantiate(cookieHouse);
                    name = go.name;
                    build = go.GetComponent<BuildBase>();
                }
            }
            
            if(Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Stop BuildMode");
                if(go != null)
                {
                    Destroy(go);
                    Debug.Log("Build Canceled");
                }
                StopCoroutine("Build");
            }
            yield return null;
        }
    }
}