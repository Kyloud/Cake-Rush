using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    public int cakeRushLevel { get; set; }
    public int cokeShotLevel { get; set; }
    public int shootingStarLevel { get; set; }
    public int lightningLevel { get; set; }

    [SerializeField] private GameObject attackRangeView;
    [SerializeField] private GameObject cokeShotField;
    [SerializeField] private LayerMask groundLayer;

    private Camera mainCamera;
    private CokeShot cokeShot;
    
    protected override void Awake()
    {
        mainCamera = Camera.main;
        
        DataLoad("Player"); 
        
        cakeRushLevel = 0;
        cokeShotLevel = 0;
        
        base.Awake();

        Debug.Log($"AttackRange : {attackRange}");
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(1))
        {
           SelectedPoint();
        }

        if(Input.GetKeyDown(KeyCode.Q))         //Coke shot
        {

        }
        else if(Input.GetKeyDown(KeyCode.W))    //Lightning
        {

        }
        else if(Input.GetKeyDown(KeyCode.E))    //Shooting star
        {

        }
        else if(Input.GetKeyDown(KeyCode.R))    //Cake rush
        {
            CakeRush();
        }
        
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("On build");
            StartCoroutine(Build(true));
        }
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            base.Stop();
        }
    }

    public override IEnumerator OutToAttakRange(Transform target)
    {
        while(attackRange < (target.position - transform.position).sqrMagnitude)
        {
            StartCoroutine(Move(target.position));
            yield return null;
        }

        StartCoroutine(BasicAttack(target));
    }

    protected override IEnumerator BasicAttack(Transform target)
    {
        WaitForSeconds attackDelay = new WaitForSeconds(attackSpeed);
        state = CharacterState.Attack;

        while((target.position - transform.position).sqrMagnitude < attackRange && state == CharacterState.Attack)
        {
            Debug.Log("Attack");
            Attack(target);
            animator.SetTrigger("Attack");
            yield return attackDelay;   
        }
    }

    protected new IEnumerator Move(Vector3 distinct)
    {
        state = CharacterState.Move;

        animator.SetTrigger("Run");

        base.Move(distinct);

        while(state == CharacterState.Move)
        {
            if(!navMashAgent.pathPending)
            {
                Debug.Log($"remianingDistance {navMashAgent.remainingDistance}");
                Debug.Log($"stoppingDistance {navMashAgent.stoppingDistance}");

                if(navMashAgent.remainingDistance <= 0.2f && navMashAgent.stoppingDistance <= 0.5f)
                {
                    if(!navMashAgent.hasPath || navMashAgent.velocity.sqrMagnitude <= 0.2f)
                    {
                        Debug.Log("Idle");
                        animator.SetTrigger("Idle");
                        state = CharacterState.Idle;
                        break;
                    }
                }
            }

            yield return null;
        }
    }

    private void SelectedPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log($"Target {hit.transform.position} as {hit.collider.gameObject.name}");

            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Debug.Log($"Hit as {hit.collider.gameObject.name} {hit.point}");
                StartCoroutine(Move(hit.point));
            }
                
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Character"))
            {
                StartCoroutine(OutToAttakRange(hit.transform));
                Debug.Log($"Hit as {hit.collider.gameObject.name}");
            }

            Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
        }
    }

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
}