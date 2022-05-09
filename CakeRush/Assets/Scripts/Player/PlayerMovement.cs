using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : EntityBase
{
    private PlayerAttack playerAttack;
    
    protected override void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void OverridingState(float moveSpeed, float attackRange, float attackSpeed)
    {
        this.moveSpeed = moveSpeed;
        this.attackRange = attackRange;
        this.attackSpeed = attackSpeed; 
        navMeshAgent.speed = moveSpeed;
    }

    public IEnumerator OutToAttakRange(Vector3 unitPosition, float range)
    {
        float distance = Vector3.SqrMagnitude(unitPosition - transform.position);

        while(Mathf.Pow(range, 2f) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, unitPosition, moveSpeed * Time.deltaTime);
            transform.LookAt(unitPosition);
            distance = Vector3.SqrMagnitude(unitPosition - transform.position);
            
            yield return null;
        }

        playerAttack.BasicAttack();
    }

    public void MoveTo(Vector3 movePoint)
    {
        navMeshAgent.SetDestination(movePoint);
        Debug.Log("Move");
    }
}
