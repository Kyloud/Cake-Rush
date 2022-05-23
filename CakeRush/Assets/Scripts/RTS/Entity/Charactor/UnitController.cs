using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 조종할 유닛의 부모클래스
public class UnitController : CharacterBase
{
    public enum CharacterState
    {
        Idle,
        Move,
        Attack,
        Stun,
        Die,    
    }
    public CharacterState state;
    
    private void Start() 
    {
        attackRange = 3f;
        attackSpeed = 1f;
        damage = 3;
        state = CharacterState.Idle;
    }   

    private Transform targetTransform = null;
    public CakeRush cakeRush;
    public Camera teamCamera;

    protected override void Awake()
    {
        teamCamera = Camera.main;
        attackRange = 3f;
        attackSpeed = 1f;
        damage = 3;
        state = CharacterState.Idle;
        base.Awake();   
    }

    protected virtual void Update()
    {
        Idle();
        Stop();
    }
    
    
    public void SelectUnit()
	{
		Marker.SetActive(true);
	}

	public void DeselectUnit()
	{
        Marker.SetActive(false);
	}

    protected virtual void Attack()
    {

    }

    void Idle()
    {
        if(Input.GetMouseButtonDown(1) && Marker.active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Stop();
                // attack cancel
                if(state == CharacterState.Attack)
                {
                    StopAllCoroutines();
                }
                // attack
                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Selectable") && (hit.transform != this.transform))
                {
                    targetTransform = hit.transform; 
                    Debug.Log("Move To Attack");
                    StartCoroutine(OutToAttakRange(hit.transform));
                }
                // move
                else
                {
                    
                    state = CharacterState.Move;
                    Debug.Log("Move");
                    Move(hit.point);
                }
                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
           }
        }
    }
    
    public virtual void Move(Vector3 destination)
    {
        navMashAgent.SetDestination(destination);
    }

    protected virtual void Stop()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            targetTransform = null;
            navMashAgent.SetDestination(transform.position);
            navMashAgent.isStopped = true;
            navMashAgent.isStopped = false; 
            StopAllCoroutines();
            state = CharacterState.Idle;
        }
    }


    public virtual IEnumerator OutToAttakRange(Transform target)
    {
        state = CharacterState.Attack;
        while(attackRange < (target.position - transform.position).sqrMagnitude)
        {
            Move(target.position);
            yield return null;
        }

        Move(transform.position);
        StartCoroutine(BasicAttack(target));
    }

	//Default Attack on Entities
	protected virtual IEnumerator BasicAttack(Transform target)
	{
		while((target.position - transform.position).sqrMagnitude < attackRange)
		{
			Debug.Log("Attack");

            if(target.CompareTag("Monster"))
            {
                target.GetComponent<MobController>().Hit(damage, transform);
            }

			yield return new WaitForSecondsRealtime(attackSpeed);
		}
        
        StartCoroutine(OutToAttakRange(target));
	}
}