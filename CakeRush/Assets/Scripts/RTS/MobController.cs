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

    protected State state;

    //variable for serching tag of target
    [SerializeField]
    public Transform target;


    protected void Update()
    {
        switch(state)
        {
            case State.idle:
                Debug.Log("IDLE");
                Idle();
                break;

            case State.attack:
                //sDebug.Log("ATTACK");
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
            state = State.attack;
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
        if(target != null)
        {
            state = State.attack;
        }
    }

    protected IEnumerator Attack()
    {
        while(true)
        {
           if(target == null)
           {
               state = State.retargeting;
               Debug.Log("retargeting");
               StopCoroutine(Attack());
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
               StopCoroutine(Attack());
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

        if(attackRange < (target.position - transform.position).sqrMagnitude)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target.position);
        }
        else
        {
            StartCoroutine(Attack());
            state = State.attack;
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
            state = State.idle;
        }
    }

    public virtual void Hit(float hitDamage, Transform attacker)
    {
        target = attacker;
        base.Hit(hitDamage);
    }

    protected void Retargeting()
    {
        
    }
}