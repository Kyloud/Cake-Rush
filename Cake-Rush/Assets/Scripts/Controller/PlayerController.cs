using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : UnitBase
{ 
    public LevelSystem levelSystem;
    private CokeShot cokeShot;
    private Lightning lightning;
    private ShootingStar shootingStar;
    private Build build;
    PhotonView PV;

    protected override void Awake()
    {
        DataLoad("Player");
        
        levelSystem = GetComponent<LevelSystem>();
        cakeRush = GetComponent<CakeRush>();
        shootingStar = GetComponent<ShootingStar>();
        lightning = GetComponent<Lightning>();
        cokeShot = GetComponent<CokeShot>();
        build = GetComponent<Build>();
        PV = GetComponent<PhotonView>();

        base.Awake();
        SkillInit();
    }

    protected override void Update()
    {
        base.Update();

        if (isSelected == false && rtsController.isSkill == false) return;
        
        rtsController.isSkill = true;
        
        #region //Use Skill
        if (Input.GetKey(KeyCode.Q) && lightning.isSkillUsed == true)             //Lightning
        {
            StartCoroutine(Lightning());
            cokeShot.isSkillUsed = false;
            shootingStar.isSkillUsed = false;
        }
        else if (Input.GetKey(KeyCode.W) && cokeShot.isSkillUsed == true)        //Coke shot
        {
            StartCoroutine(CokeShot());
            lightning.isSkillUsed = false;
            shootingStar.isSkillUsed = false;
        }
        else if (Input.GetKey(KeyCode.E) && shootingStar.isSkillUsed == true)        //Shooting star
        {
            ShootingStar();
            lightning.isSkillUsed = false;
            cokeShot.isSkillUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))        //Cake rush
        {
            CakeRush();
        }
        else
        {
            rtsController.isSkill = false;

            lightning.rangeViewObj.SetActive(false);
            cokeShot.rangeViewObj.SetActive(false);
            shootingStar.rangeViewObj.SetActive(false);

            lightning.isSkillUsed = true;
            cokeShot.isSkillUsed = true;
            shootingStar.isSkillUsed = true;
        }
        #endregion

        if(Input.GetKey(KeyCode.LeftControl) && levelSystem.skillPoint > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                levelSystem.SkillLevelUp(lightning);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                levelSystem.SkillLevelUp(cokeShot);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                levelSystem.SkillLevelUp(shootingStar);
            }
            else if (Input.GetKeyDown(KeyCode.R) && levelSystem.curLevel > 6)
            {
                levelSystem.SkillLevelUp(cakeRush);
            }
        }

        if (Input.GetKeyDown(KeyCode.B) && build.isBuildMode == false)      //Build
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

        if (target.CompareTag("Monster"))
        {
            SearchTarget(target.GetComponent<MobBase>());
        }
        else if (target.CompareTag("Build"))
        {
            SearchTarget(target.GetComponent<BuildBase>());
        }
        else if (target.CompareTag("Unit"))
        {
            SearchTarget(target.GetComponent<UnitBase>());
        }
    }

    private void SearchTarget <T> (T target) where T : EntityBase
    {
        if(target is MobBase)
        {
            target.GetComponent<MobBase>().Hit(damage, transform);
        }
        else if(target is UnitBase)
        {
            target.GetComponent<UnitBase>().Hit(damage);
        }
        else if (target is BuildBase)
        {
            target.GetComponent<BuildBase>().Hit(damage);
        }

        if (target.curHp <= 0)
        {
            levelSystem.GetExp(target.returnExp);
        }
    }

    private void SkillInit()
    {
        cakeRush.isSkillable = true;
        cokeShot.isSkillable = true;
        lightning.isSkillable = true;
        shootingStar.isSkillable = true;

        shootingStar.range = 6f;
        lightning.range = 30f;
        cokeShot.range = 80f;
        cokeShot.radius = 5f;
    }

    private IEnumerator Lightning()
    {
        lightning.rangeViewObj.SetActive(true);
        
        if (Input.GetMouseButtonDown(0))
        {
            if(!lightning.skillStat[lightning.level].isCoolTime)
            {
                lightning.rangeViewObj.SetActive(false);

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
                    animator.SetTrigger("Lightning");
                    yield return new WaitForSeconds(0.2f);
                
                    animator.SetBool("Move", false);
                    state = CharacterState.Idle;
                    lightning.UseSkill(lightning.level, hit.collider);

                    animator.SetBool("Idle", true);
                }
            }
        }
    }

    private IEnumerator CokeShot()
    {
        cokeShot.rangeViewObj.SetActive(true);

        if (Input.GetMouseButtonDown(0) && !cokeShot.skillStat[lightning.level].isCoolTime)
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

                cokeShot.UseSkill(cokeShot.level, hit.point);
                StopMove();
            }
        }
    }

    private void ShootingStar()
    {
        shootingStar.rangeViewObj.SetActive(true);

        if (Input.GetMouseButtonDown(0) && !shootingStar.skillStat[lightning.level].isCoolTime)
        {
            Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            StopCoroutine("Move");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(hit.point - transform.position), 90);

                Quaternion originRot = transform.rotation;
                
                shootingStar.UseSkill(shootingStar.level, originRot.eulerAngles);
                StopMove();
                Debug.DrawRay(Camera.main.transform.position, hit.point, Color.blue, 1f);
            }
        }
    }

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.level);
    }

    private void StopMove()
    {
        navMashAgent.Stop();
        animator.SetBool("Move", false);
        state = CharacterState.Idle;
    }

    private IEnumerator BuildMode()
    {
        if (build.isBuildMode == true) yield break;
        Debug.Log("BuildMode");
        build.isBuildMode = true;
        GameObject go = null;
        RaycastHit hit;
        BuildBase buildBase = null;
        string curBuildName = null;

        yield return null;
        while (true)
        {
            if (go != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 5000f, GameProgress.instance.groundLayer))
                {
                    go.transform.position = hit.point;
                }
                if (Input.GetMouseButtonDown(0) && ((hit.point) - transform.position).magnitude < 30f
                    && buildBase.isOnSelectable == false)
                {
                    StartCoroutine(buildBase.Build());
                    go = null;
                    Debug.Log("Build!");
                    curBuildName = null;
                    build.isBuildMode = false;
                    yield break;
                }

                if (Input.GetKey(KeyCode.Alpha1))
                {
                    go.transform.Rotate(Vector3.down * Time.deltaTime * 90f);
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    go.transform.Rotate(Vector3.up * Time.deltaTime * 90f);
                }
            }

            if (Input.GetKeyDown(KeyCode.A) && curBuildName != build.cookieHouseName)
            {
                if (go != null) Destroy(go);

                Debug.Log("A");
                go = Instantiate(build.cookieHouseObj);
                curBuildName = build.cookieHouseName;
                buildBase = go.GetComponent<BuildBase>();
            }
            if (Input.GetKeyDown(KeyCode.S) && curBuildName != build.sugerMinerName)
            {
                if (go != null) Destroy(go);
                Debug.Log("S");
                go = Instantiate(build.sugarMinerObj);
                curBuildName = build.sugerMinerName;
                buildBase = go.GetComponent<BuildBase>();
            }
            if (Input.GetKeyDown(KeyCode.D) && curBuildName != build.chocolateMinerName)
            {
                if (go != null) Destroy(go);
                Debug.Log("D");
                go = Instantiate(build.chocolateMinerObj);
                curBuildName = build.chocolateMinerName;
                buildBase = go.GetComponent<BuildBase>();
            }

            else if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Stop BuildMode");
                if (go != null)
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

    protected override void Die()
    {
        animator.SetTrigger("Die");
        base.Die();
    }
}