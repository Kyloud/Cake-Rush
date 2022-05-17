using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 조종할 유닛의 부모클래스
public class UnitController : CharacterBase
{
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
    public virtual void Move(Vector3 destination)
    {
        navMashAgent.SetDestination(destination);
    }

    protected virtual void Stop()
    {

    }

    public virtual IEnumerator OutToAttakRange(Vector3 unitPosition, float range)
    {
        float distance = Vector3.SqrMagnitude(unitPosition - transform.position);

        while(Mathf.Pow(range, 2f) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, unitPosition, moveSpeed * Time.deltaTime);
            transform.LookAt(unitPosition);
            distance = Vector3.SqrMagnitude(unitPosition - transform.position);
            
            yield return null;
        }
    }

	//Default Attack on Entities
	protected virtual IEnumerator BasicAttack(Vector3 targetPosition)
	{
		float distance = (targetPosition - transform.position).sqrMagnitude;

		while(distance < attackRange)
		{
			Debug.Log("Attack");
			yield return null;
		}
	}
}