using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//중립 몬스터의 부모 클래스
public class MobController : CharacterBase
{
    protected Vector3 originPos;
    protected float distance;

    //임시
    protected float distanceToHomebase;

    protected override void Awake()
    {
        base.Awake();
        originPos = transform.position;
        state = State.idle;
        distanceToHomebase = 6f;
        attackRange = 5f;
        moveSpeed = 4f;
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
                Debug.Log("ATTACK");
                Attack();
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
        
    }

    protected void Attack()
    {
        if(target == null)
        {
            state = State.retargeting;
            return ;
        }

        distance = Vector3.SqrMagnitude(target.position - transform.position);
        if(Mathf.Pow(attackRange, 2f) >= distance)
        {
            target.GetComponent<EntityBase>().Hit(damage);
        }
        else
        {
            state = State.move;
        }
    }

    //move function for trace
    protected void Move()
    {
        distance = Vector3.SqrMagnitude(target.position - transform.position);

        if(Mathf.Pow(attackRange-1, 2f) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target.position);

            //check, is it out homebase
            distance = Vector3.SqrMagnitude(originPos - transform.position);
            if(Mathf.Pow(distanceToHomebase, 2f) < distance)
            {
                state = State.reset;
            }
        }
        else
        {
            state = State.attack;
        }
    }

    protected void Reset()
    {
        distance = Vector3.SqrMagnitude(originPos - transform.position);

        if(0.1f < distance)
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