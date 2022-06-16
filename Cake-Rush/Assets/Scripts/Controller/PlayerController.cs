using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : UnitBase
{
    private CokeShot cokeShot;
    private Lightning lightning;
    private ShootingStar shootingStar;
    private Build build;
    PhotonView PV;
    
    protected override void Awake()
    {
        DataLoad("Player");

        cakeRush = GetComponent<CakeRush>();
        shootingStar = GetComponent<ShootingStar>();
        lightning = GetComponent<Lightning>();
        cokeShot = GetComponent<CokeShot>();
        build = GetComponent<Build>();
        PV = GetComponent<PhotonView>();
        base.Awake();
        SkillInit();

        attackRange = 30f;
    }

    protected override void Update()
    {
        base.Update();

        if (isSelected == false) return;
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
        else if (Input.GetKeyDown(KeyCode.B) && build.isBuildMode == false)
        {
            StartCoroutine(BuildMode());
        }

        /*if (PV.IsMine)
        {
            base.Update();

            if (isSelected == false) return;
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
            else if (Input.GetKeyDown(KeyCode.B) && build.isBuildMode == false)
            {
                StartCoroutine(BuildMode());
            }
        }*/
    }

    protected override void Attack (Transform target)
    {
        state = CharacterState.Attack;

        navMashAgent.isStopped = true;

        animator.SetBool("Move", false);
        animator.SetBool("Attack", true);

        if(target.CompareTag("Monster"))
        {
            target.GetComponent<MobController>().Hit(damage, transform);
        }
        else
        {
            target.GetComponent<EntityBase>().Hit(damage);
        }
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
                lightning.UseSkill(lightning.level, hit.collider.GetComponent<CharacterBase>());
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

                shootingStar.UseSkill(shootingStar.level, Vector3.zero);
                Debug.DrawRay(Camera.main.transform.position, hit.point, Color.blue, 1f);
            }
        }
    }

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.level);
    }

    private IEnumerator BuildMode()
    {
        if(build.isBuildMode == true) yield break;
        Debug.Log("BuildMode");
        build.isBuildMode = true;
        GameObject go = null;
        RaycastHit hit;
        BuildBase buildBase = null;
        string curBuildName = null;   

        yield return null;
        while(true)
        {
            if(go != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 5000f, GameProgress.instance.groundLayer))
                {
                    go.transform.position = hit.point;
                }
                if(Input.GetMouseButtonDown(0) && ((hit.point) - transform.position).magnitude < 5f)
                {
                    StartCoroutine(buildBase.Build());
                    go = null;
                    Debug.Log("Build!");
                    curBuildName = null;
                    build.isBuildMode = false;
                    yield break;
                }
            }
            
            //Input
            if(go == null)
            {
                if(Input.GetKeyDown(KeyCode.A) && curBuildName != build.cookieHouseName)
                {
                    go = Instantiate(build.cookieHouseObj);
                    curBuildName = build.cookieHouseName;
                    buildBase = go.GetComponent<BuildBase>();
                }
                else if (Input.GetKeyDown(KeyCode.S) && curBuildName != build.costBuildName)
                {
                    go = Instantiate(build.cookieHouseObj);
                    curBuildName = build.costBuildName;
                    buildBase = go.GetComponent<BuildBase>();
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
                build.isBuildMode = false;
                yield break;
            }
            yield return null;
        }
    }
}