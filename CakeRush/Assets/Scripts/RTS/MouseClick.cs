using UnityEngine;

public class MouseClick : MonoBehaviour
{
	[SerializeField] private LayerMask layerSelectable;
	[SerializeField] private LayerMask layerGround;

	private	Camera mainCamera;
	private	RTSUnitController rtsUnitController;
	private	RTSBuildingController rtsBuildingController;

	private void Awake()
	{
		mainCamera = Camera.main;
		rtsUnitController = GetComponent<RTSUnitController>();
		rtsBuildingController = GetComponent<RTSBuildingController>();
	}

	private void Update()
	{
		// select or deselect by click
		if ( Input.GetMouseButtonDown(0) )
		{
			RaycastHit	hit;
			Ray	ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			// When there is an object hitting the ray (= clicking on the unit)
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerSelectable))
			{
				if (hit.transform.GetComponent<UnitController>() == null) return;

				if(hit.transform.CompareTag("Unit"))
				{
					if (Input.GetKey(KeyCode.LeftShift))
					{
						rtsUnitController.ShiftClickSelectUnit(hit.transform.GetComponent<UnitController>());
					}
					else
					{
						rtsUnitController.ClickSelectUnit(hit.transform.GetComponent<UnitController>());
					}
				}
				else if (hit.transform.CompareTag("Building"))
				{
					if (Input.GetKey(KeyCode.LeftShift))
					{
						rtsBuildingController.ShiftClickSelectBuilding(hit.transform.GetComponent<BuildingController>());
					}
					else
					{
						rtsBuildingController.ClickSelectBuilding(hit.transform.GetComponent<BuildingController>());
					}
				}
			}
			// When no object hits the ray
			else
			{
				if (!Input.GetKey(KeyCode.LeftShift) )
				{
					rtsUnitController.DeselectAll();
					rtsBuildingController.DeselectAll();
				}
			}
		}

		// move units by right-clicking
		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit	hit;
			Ray	ray = mainCamera.ScreenPointToRay(Input.mousePosition);
	
			// When the unit object (layerUnit) is clicked
			if ( Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround) )
			{
				rtsUnitController.MoveSelectedUnits(hit.point);
			}
		}
	}
}

