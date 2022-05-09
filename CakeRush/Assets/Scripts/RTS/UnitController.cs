using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class UnitController : EntityBase
{
	[SerializeField]
	private	GameObject		unitMarker;
	
	protected override void Awake()
	{
		base.Awake();
	}

	public void SelectUnit()
	{
		unitMarker.SetActive(true);
	}

	public void DeselectUnit()
	{
		unitMarker.SetActive(false);
	}

	//Go to Click Point
	public virtual void MoveTo(Vector3 end)
	{
		navMeshAgent.SetDestination(end);
	}

	//Follow the target outside the range until it enters the range
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

