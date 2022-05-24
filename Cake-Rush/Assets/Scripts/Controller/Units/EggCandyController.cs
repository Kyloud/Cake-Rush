using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCandyController : UnitController
{

    protected override void Awake()
    {
        DataLoad("EggCandy");
        base.Awake();
        navMashAgent.speed = moveSpeed;
        gameObject.GetComponent<FieldOfView>().viewRadius = eyeSight;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack(Transform target)
    {        
        base.Attack(target);
        this.Attack();
    }

    protected void Attack()
    {        
        animator.SetBool("Move", false);
        animator.SetBool("Attack", true);
    }

    protected override void Stop()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            targetTransform = null;
            navMashAgent.SetDestination(transform.position);
            navMashAgent.isStopped = true;
            navMashAgent.isStopped = false; 
            StopAllCoroutines();
            state = CharacterState.Idle;
            animator.SetBool("Move", false);
            animator.SetBool("Attack", false);
        }
    }
}
