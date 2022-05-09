using System.Collections.Generic;
using UnityEngine;

public class RTSBuildingController : MonoBehaviour
{
	// Units selected by the player by clicking or dragging
	private	List<BuildingController> selectedBuildingList = new List<BuildingController>();
	
	// All units on the map
	public List<BuildingController> BuildingList = new List<BuildingController>();	

	private void Awake()
	{

	}

	/// <summary>
	/// Called when a unit is selected with a mouse click
	/// </summary>
	public void ClickSelectBuilding(BuildingController newBuilding)
	{
		// Remove all units selected in the zone
		DeselectAll();
		SelectBuilding(newBuilding);
	}

	/// <summary>
	/// Invoked when selecting a unit with Shift+mouse click
	/// </summary>
	public void ShiftClickSelectBuilding(BuildingController newBuilding)
	{
		// If you select a previously selected unit
		if ( selectedBuildingList.Contains(newBuilding) )
		{
			DeselectBuilding(newBuilding);
		}
		// If you choose a new unit
		else
		{
			SelectBuilding(newBuilding);
		}
	}

	/// <summary>
	/// Called when selecting a unit by mouse dragging
	/// </summary>
	public void DragSelectBuilding(BuildingController newBuilding)
	{
		// If you choose a new unit
		if (!selectedBuildingList.Contains(newBuilding))
		{
			SelectBuilding(newBuilding);
		}
	}
	
	/// <summary>
	/// Called when all units are deselected
	/// </summary>
	public void DeselectAll()
	{
		for ( int i = 0; i < selectedBuildingList.Count; ++ i )
		{
			selectedBuildingList[i].DeselectUnit();
		}

		selectedBuildingList.Clear();
	}

	/// <summary>
	/// NewUnit selection set received as a parameter
	/// </summary>
	private void SelectBuilding(BuildingController newBuilding)
	{
		// Method to be called when a unit is selected
		newBuilding.SelectUnit();
		// Save the selected unit information to the list
		selectedBuildingList.Add(newBuilding);
	}
	
	/// <summary>
	/// Set deselection of newUnit received as a parameter
	/// </summary>
	private void DeselectBuilding(BuildingController newBuilding)
	{
		// Method called when unit is released
		newBuilding.DeselectUnit();
		// Delete the selected unit information from the list
		selectedBuildingList.Remove(newBuilding);
	}
}
