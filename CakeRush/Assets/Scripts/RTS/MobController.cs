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
        distanceToHomebase = 100f;
        attackRange = 5f;
        moveSpeed = 4f;
        second = new WaitForSeconds(1);;
        //target = null;
    }

    public enum State
    {
        idle, attack, move, reset, retargeting
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


    protected void Update()
    {
        switch(state)
        {
            case State.idle:
                Debug.Log("IDLE");
                Idle();
                break;

            case State.attack:
                Debug.Log("ATTACK");
                
        
                break;

            case State.move:
                Debug.Log("MOVE");
                Move();
                break;

            case State.retargeting:
                Debug.Log("RETARGETING");
                Retargeting();
                break;

            case State.reset:
                Debug.Log("RESET");
                Reset();
                break;

            default:
                break;

        }


        if(Input.GetKeyDown(KeyCode.Alpha1)){
            state = State.idle;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(state != State.attack)
            {
                state = State.attack;
                StartCoroutine(Attack());
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            state = State.move;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            state = State.retargeting;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            state = State.reset;
        }
    }

    protected void Idle()
    {
        //play IDLE animation
    }

    protected IEnumerator Attack()
    {
        while(true)
        {
            Debug.Log("attacking");
           if(target == null)
           {
               state = State.retargeting;
               Debug.Log("retargeting");
               break;
           }

          if(attackRange >= (target.position - transform.position).sqrMagnitude)
          {
               target.GetComponent<UnitController>().Hit(damage);
               Debug.Log("Hit");
               yield return second;
           }
            else
           {
               state = State.move;
               Debug.Log("move");
               break;
           }

        }
    }

    //move function for trace
    protected void Move()
    {

        //check, is it out homebase
        if(distanceToHomebase < (originPos - transform.position).sqrMagnitude || distanceToHomebase < (originPos - target.position).sqrMagnitude)
        {
            state = State.reset;
        }

        //check is target in my attack range
        if(attackRange < (target.position - transform.position).sqrMagnitude)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target.position);
        }
        else
        {
            //in range
            if(state != State.attack)
            {
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
            transform.position = Vector3.MoveTowards(transform.position, originPos, moveSpeed * Time.deltaTime);
            transform.LookAt(originPos);
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
        
        if(state != State.attack)
        {
            state = State.attack;
            StartCoroutine(Attack());
        }
    }

    protected void Retargeting()
    {
        
    }
}