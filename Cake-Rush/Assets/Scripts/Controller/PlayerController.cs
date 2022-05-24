using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
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

        Debug.Log($"AttackRange : {attackRange}");
    }

    protected override void Attack(Transform target)
    {
        state = CharacterState.Attack;

        navMashAgent.isStopped = true;

        animator.SetBool("Move", false);
        animator.SetBool("Attack", true);

        target.GetComponent<EntityBase>().Hit(damage);
    }

    public override void Move(Vector3 destination)
    {
        state = CharacterState.Move;

        Debug.Log("Move");

        animator.SetBool("Move", true);
        animator.SetBool("Attack", false);
        
        navMashAgent.isStopped = false; 

        navMashAgent.SetDestination(destination);

        StartCoroutine(Arrive());
    }

    public override IEnumerator OutToAttakRange(Transform target)
    {
        animator.SetBool("Move", true);
        animator.SetBool("Attack", false);

        while(attackRange < (target.position - transform.position).sqrMagnitude)
        {
            navMashAgent.SetDestination(target.position);
            yield return null;
        }

        StartCoroutine(BasicAttack(target));
    }

    protected override IEnumerator BasicAttack(Transform target)
    {
        state = CharacterState.Attack;

        animator.SetBool("Move", false);
        animator.SetBool("Attack", true);

        WaitForSeconds speed = new WaitForSeconds(attackSpeed);

		while((target.position - transform.position).sqrMagnitude < attackRange)
		{
            Attack(target);

			yield return speed;
		}
    }

    protected override void Update()
    {
        base.Update();
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
                Move(hit.point);
            }
                
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Selectable"))
            {
                StartCoroutine(OutToAttakRange(hit.transform));
            }

            Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
        }
    }

    private void CakeRush()
    {
        cakeRush.UseSkill(cakeRush.skillLevel);
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