using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
	[SerializeField]
	private	UnitSpawner	unitSpawner;
	private	List<UnitController> selectedUnitList;				// Units selected by the player by clicking or dragging
	public	List<UnitController> UnitList { private set; get; }	// All units on the map

	private void Awake()
	{
		selectedUnitList = new List<UnitController>();
		//UnitList = unitSpawner.SpawnUnits();
		
	}

	/// <summary>
	/// Called when a unit is selected with a mouse click
	/// </summary>
	public void ClickSelectUnit(UnitController newUnit)
	{
		// Remove all units selected in the zone
		DeselectAll();
		SelectUnit(newUnit);
	}

	/// <summary>
	/// Invoked when selecting a unit with Shift+mouse click
	/// </summary>
	public void ShiftClickSelectUnit(UnitController newUnit)
	{
		// If you select a previously selected unit
		if ( selectedUnitList.Contains(newUnit) )
		{
			DeselectUnit(newUnit);
		}
		// If you choose a new unit
		else
		{
			SelectUnit(newUnit);
		}
	}

	/// <summary>
	/// Called when selecting a unit by mouse dragging
	/// </summary>
	public void DragSelectUnit(UnitController newUnit)
	{
		// If you choose a new unit
		if (!selectedUnitList.Contains(newUnit) )
		{
			SelectUnit(newUnit);
		}
	}

	/// <summary>
	/// Called to move all selected units
	/// </summary>
	public void MoveSelectedUnits(Vector3 end)
	{
		for ( int i = 0; i < selectedUnitList.Count; ++ i )
		{
			selectedUnitList[i].MoveTo(end);
		}
	}

	/// <summary>
	/// Called when all units are deselected
	/// </summary>
	public void DeselectAll()
	{
		for ( int i = 0; i < selectedUnitList.Count; ++ i )
		{
			selectedUnitList[i].DeselectUnit();
		}

		selectedUnitList.Clear();
	}

	/// <summary>
	/// NewUnit selection set received as a parameter
	/// </summary>
	private void SelectUnit(UnitController newUnit)
	{
		// Method to be called when a unit is selected
		newUnit.SelectUnit();
		// Save the selected unit information to the list
		selectedUnitList.Add(newUnit);
	}

	/// <summary>
	/// Set deselection of newUnit received as a parameter
	/// </summary>
	private void DeselectUnit(UnitController newUnit)
	{
		// Method called when unit is released
		newUnit.DeselectUnit();
		// Delete the selected unit information from the list
		selectedUnitList.Remove(newUnit);
	}
}

