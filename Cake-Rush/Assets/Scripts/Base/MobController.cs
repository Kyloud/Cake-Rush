using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//중립 몬스터의 부모 클래스
public class MobController : CharacterBase
{
    protected Vector3 originPos;
    //임시
    protected float distanceToHomebase;
    protected WaitForSeconds second;

    protected override void Awake()
    {
        base.Awake();
        originPos = transform.position;
        state = State.idle;
        distanceToHomebase = eyeSight;
        second = new WaitForSeconds(1);
        //target = null;
    }

    public enum State
    {
        idle, attack, move, reset, retargeting, die
    }

    [SerializeField]
    protected State state;

    //variable for serching tag of target
    [SerializeField]
    public Transform target;

    public void SelectUnit()
	{
		Marker.SetActive(true);
	}

	public void DeselectUnit()
	{
        Marker.SetActive(false);
	}


    protected override void Update()
    {
        switch(state)
        {
            case State.attack:
                break;

            case State.move:
                Move();
                break;

            case State.retargeting:
                Retargeting();
                break;

            case State.reset:
                Reset();
                break;

            default:
                break;
        }

        animator.SetBool("Attack", state == State.attack);
        animator.SetBool("Move", state == State.move || state == State.reset);
    }

    protected override void Die()
    {
        base.Die();
        animator.SetTrigger("Die");
        state = State.die;
        Destroy(gameObject, 3f);
    }

    protected IEnumerator Attack()
    {
        while(true)
        {
           if(target == null)
           {
               state = State.retargeting;
               break;
           }

          if(attackRange >= (target.position - transform.position).sqrMagnitude)
          {
                transform.LookAt(target);
               target.GetComponent<UnitBase>().Hit(damage);
               yield return second;
          }
          else
          {
               state = State.move;
               break;
          }

        }
    }

    //move function for trace
    protected virtual void Move()
    {

        //check, is it out homebase
        if(distanceToHomebase < Vector3.Distance(originPos, transform.position)|| distanceToHomebase < Vector3.Distance(originPos, target.position))
        {
            state = State.reset;
        }

        //check is target in my attack range
        if(attackRange < (target.position - transform.position).sqrMagnitude)
        {
            navMashAgent.SetDestination(target.position);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //transform.LookAt(target.position);
        }
        else
        {
            //in range
            if(state != State.attack)
            {
                navMashAgent.ResetPath();
                state = State.attack;
                StartCoroutine("Attack");
            }
        }
    }

    protected void Reset()
    {
        //0.1f is move mistake proofread
        if(0.1f < (originPos - transform.position).sqrMagnitude)
        {
            //transform.position = Vector3.MoveTowards(transform.position, originPos, moveSpeed * Time.deltaTime);

            navMashAgent.SetDestination(originPos);
            //transform.LookAt(originPos);
        }
        else
        {
            target = null;
            state = State.idle;
        }
    }

    public virtual void Hit(float hitDamage, Transform attacker)
    {
        base.Hit(hitDamage);

        if (state != State.attack)
        {
            state = State.attack;
            target = attacker;
            StartCoroutine(Attack());
        }
    }

    protected void Retargeting()
    {
        
    }
}