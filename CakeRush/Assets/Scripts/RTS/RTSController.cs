using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 내 Entity를 관리하는 시스템 클래스
public class RTSController : MonoBehaviour
{
    
    public List<UnitController> selectedUnitList = new List<UnitController>();
    public List<UnitController> unitList = new List<UnitController>();
    public List<BuildController> selectedBuildList = new List<BuildController>();
    public List<BuildController> buildList = new List<BuildController>();
	public EntityBase selectedEnemyEntity;
    
	private Camera teamCamera;
    
	public LayerMask layerGround = 1 << 6;
    public LayerMask layerSelectable = 1 << 7;

	[SerializeField] RectTransform dragRectangle;
	private Rect dragRect;
	private Vector2 start = Vector2.zero;
	private Vector2 end = Vector2.zero;
    
	void Awake()
    {
		teamCamera = Camera.main;
		//Find Team Camera
		DrawDragRectangle();
    }

    void Update() 
	{
        Click();
		Drag();
    }

    void Click()
    {
			// When there is an object hitting the ray (= clicking on the unit)
		if ( Input.GetMouseButtonDown(0) )
		{
			Ray	ray = teamCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			// When there is an object hitting the ray (= clicking on the unit)
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerSelectable))
			{
				if (hit.transform.gameObject.GetComponent<EntityBase>() == null)
					return;
				
				if(hit.transform.gameObject.CompareTag("Unit"))
				{
					Debug.Log($"hit Unit, {hit.transform.gameObject.name}");
					selectedBuildList.Clear();
					if (Input.GetKey(KeyCode.LeftShift))
					{
						ShiftClickSelectUnit(hit.transform.gameObject.GetComponent<UnitController>());
					}
					else
					{
						ClickSelectUnit(hit.transform.gameObject.GetComponent<UnitController>());
					}
				}
				else if(hit.transform.gameObject.CompareTag("Build"))
				{
					Debug.Log($"hit Build, {hit.transform.gameObject.name}");
					selectedUnitList.Clear();
					if (Input.GetKey(KeyCode.LeftShift))
					{
						ShiftClickSelectUnit(hit.transform.gameObject.GetComponent<BuildController>());
					}
					else
					{
						ClickSelectUnit(hit.transform.gameObject.GetComponent<BuildController>());
					}
				}
				
				Debug.DrawLine(teamCamera.transform.position, hit.point, Color.red, 1f);
				return;
			}
				//When ray is hitting ground.
			else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
			{
				if (!Input.GetKey(KeyCode.LeftShift) )
				{
					DeselectAllUnit();
				}
				Debug.DrawLine(teamCamera.transform.position, hit.point, Color.red, 1f);
			}

		}
		// move units by right-clicking
		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit	hit;
			Ray	ray = teamCamera.ScreenPointToRay(Input.mousePosition);
			// When the unit object (layerUnit) is clicked
			if ( Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
			{
				//MoveSelectedUnits(hit.point);
				Debug.DrawLine(teamCamera.transform.position, hit.point, Color.red, 1f);
				return;
			}
			else
			{
				Debug.DrawLine(teamCamera.transform.position, hit.point, Color.red, 1f);
			}
		}
    }

	void Drag()
	{
		if (Input.GetMouseButtonDown(0))
		{
			start = Input.mousePosition;
			dragRect = new Rect();
		}

		if ( Input.GetMouseButton(0) )
		{
			end = Input.mousePosition;
			
			// Represents the drag range as an image while dragging with the mouse clicked
			DrawDragRectangle();
			
			Ray ray = teamCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if ( Physics.Raycast(ray, out hit, Mathf.Infinity))
				Debug.DrawLine(teamCamera.transform.position, hit.point, Color.green, 1f);
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			// Select the unit within the drag range when the mouse click ends
			CalculateDragRect();
			SelectUnits();

			// Make the drag range invisible when you end the mouse click
			// Set the start and end positions to (0, 0) and draw the drag range
			start = end = Vector2.zero;
			DrawDragRectangle();
		}
	}
	
	/// Called when a unit is selected with a mouse click
	public void ClickSelectUnit<T>(T newEntity) where T : EntityBase
	{
		// Remove all units selected in the zone
		DeselectAllUnit();
		SelectUnit<T>(newEntity);
	}

	/// Invoked when selecting a unit with Shift+mouse click
	public void ShiftClickSelectUnit<T>(T newEntity)
	{
		if(typeof(T).Name == "UnitController")
		{
			if ( selectedUnitList.Contains(newEntity as UnitController))
			{
				DeselectUnit(newEntity as UnitController);
			}
			// If you choose a new unit
			else
			{
				SelectUnit(newEntity as UnitController);
			}
		}
		else if(typeof(T).Name == "BuildController")
		{
			if ( selectedBuildList.Contains(newEntity as BuildController) )
			{
				DeselectUnit(newEntity as BuildController);
			}
			// If you choose a new unit
			else
			{
				SelectUnit(newEntity as BuildController);
			}
		}
		// If you select a previously selected unit
		// if ( selectedUnitList.Contains(newEntity) )
		// {
		// 	DeselectUnit(newEntity);
		// }
		// // If you choose a new unit
		// else
		// {
		// 	SelectUnit(newEntity);
		// }
	}

	/// Called when selecting a unit by mouse dragging
	public void DragSelectUnit<T>(T newEntity) where T : EntityBase
	{
		// If you choose a new unit
		if(typeof(T).Name == "UnitController")
		{
			if (!selectedUnitList.Contains(newEntity as UnitController))
			{
				SelectUnit(newEntity);
			}
		}
		else if(typeof(T).Name == "BuildController")
		{
			if (!selectedBuildList.Contains(newEntity as BuildController))
			{
				SelectUnit(newEntity);
			}
		}
	}

	/// Called to move all selected units
	public void MoveSelectedUnits(Vector3 end)
	{
		for ( int i = 0; i < selectedUnitList.Count; ++ i )
		{
			selectedUnitList[i].Move(end);		
		}
	}

	/// Called when all units are deselected
	public void DeselectAllUnit()
	{
		for ( int i = 0; i < selectedUnitList.Count; ++ i )
		{
			selectedUnitList[i].Deselect();
		}
		for ( int j = 0; j < selectedBuildList.Count; ++ j )
		{
			selectedBuildList[j].Deselect();
		}
		selectedUnitList.Clear();
		selectedBuildList.Clear();
	}

	/// NewUnit selection set received as a parameter
	private void SelectUnit<T>(T newEntity) where T : EntityBase
	{
		// Method to be called when a unit is selected
		newEntity.Select();
		// Save the selected unit information to the list
		if(typeof(T).Name == "UnitController")
		{
			selectedUnitList.Add(newEntity.gameObject.GetComponent<UnitController>());
			Debug.Log("Unit");
		}
		else if(typeof(T).Name == "BuildController")
		{
			selectedBuildList.Add(newEntity.gameObject.GetComponent<BuildController>());
			Debug.Log("build");
		}
	}

	/// Set deselection of newEntity received as a parameter
	private void DeselectUnit<T>(T newEntity) where T : EntityBase
	{
		// Method called when unit is released
		newEntity.Deselect();
		// Delete the selected unit information from the list
		
		if(typeof(T).Name == "UnitController")
		{
			selectedUnitList.Remove(newEntity as UnitController);
		}
		else if(typeof(T).Name == "BuildController")
		{
			selectedBuildList.Remove(newEntity as BuildController);
		}
	}
	
	private void DrawDragRectangle()
	{
		// Position of Image UI indicating drag range
		dragRectangle.position	= (start + end) * 0.5f;
		// Size of Image UI indicating drag range
		dragRectangle.sizeDelta	= new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
	}

	private void CalculateDragRect()
	{
		if ( Input.mousePosition.x < start.x )
		{
			dragRect.xMin = Input.mousePosition.x;
			dragRect.xMax = start.x;
		}
		else
		{
			dragRect.xMin = start.x;
			dragRect.xMax = Input.mousePosition.x;
		}

		if ( Input.mousePosition.y < start.y )
		{
			dragRect.yMin = Input.mousePosition.y;
			dragRect.yMax = start.y;
		}
		else
		{
			dragRect.yMin = start.y;
			dragRect.yMax = Input.mousePosition.y;
		}
	}

	private void SelectUnits()
	{
		// check all units
 		foreach (UnitController unit in unitList)
		{
			// Converts the unit's world coordinates to screen coordinates to check if they are within the drag range
			if ( dragRect.Contains(teamCamera.WorldToScreenPoint(unit.transform.position)) == true)
			{
				DragSelectUnit(unit);
			}
		}
		foreach (BuildController build in buildList)
		{
			// Converts the unit's world coordinates to screen coordinates to check if they are within the drag range
			if ( dragRect.Contains(teamCamera.WorldToScreenPoint(build.transform.position)) == true)
			{
				DragSelectUnit(build);
			}
		}
	}
}