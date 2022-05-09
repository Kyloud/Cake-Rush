using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
	[SerializeField]
	private	GameObject		unitMarker;
	private	NavMeshAgent	navMeshAgent;

	[SerializeField] private bool isBuilding;
	private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void SelectUnit()
	{
		unitMarker.SetActive(true);
	}

	public void DeselectUnit()
	{
		unitMarker.SetActive(false);
	}

	public void MoveTo(Vector3 end)
	{
		if(isBuilding)
			return;
		navMeshAgent.SetDestination(end);
	}


}

