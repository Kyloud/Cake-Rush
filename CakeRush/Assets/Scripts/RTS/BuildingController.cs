using UnityEngine;
using UnityEngine.AI;

public class BuildingController : MonoBehaviour
{
	[SerializeField] private GameObject buildingMarker;

	private void Awake()
	{

	}


	public void SelectUnit()
	{
		buildingMarker.SetActive(true);
	}

	public void DeselectUnit()
	{
		buildingMarker.SetActive(false);
	}
}

