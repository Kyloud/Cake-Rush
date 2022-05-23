using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCandyController : UnitController
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
    
    public override void Move(Vector3 distinct)
    {
        animator.SetBool("Move", true);
        animator.SetBool("Attack", false);
        base.Move(distinct);
        StartCoroutine(Move());
    }
    
    protected IEnumerator Move()
    {
        while(true)
        {
            if(!navMashAgent.pathPending)
            {
               if(navMashAgent.remainingDistance <= navMashAgent.stoppingDistance)
               {
                   if(!navMashAgent.hasPath || navMashAgent.velocity.sqrMagnitude == 0)
                    {
                        animator.SetBool("Move", false);
                        state = CharacterState.Idle;
                        break;
                    }
               }
            }

            yield return null;
        }
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
