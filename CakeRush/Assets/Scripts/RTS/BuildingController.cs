using UnityEngine;


public class BuildingController : MonoBehaviour
{
	[SerializeField] private GameObject buildingMarker;

	private void Awake()
	{

	}


	public void SelectBuilding()
	{
		buildingMarker.SetActive(true);
	}

	public void DeselectBuilding()
	{
		buildingMarker.SetActive(false);
	}
}

