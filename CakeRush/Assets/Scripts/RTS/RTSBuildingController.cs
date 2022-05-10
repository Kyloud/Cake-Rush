using System.Collections.Generic;
using UnityEngine;

public class RTSBuildingController : MonoBehaviour
{
	// Buildings selected by the player by clicking or dragging
	private	List<BuildingController> selectedBuildingList = new List<BuildingController>();
	
	// All Buildings on the map
	public List<BuildingController> BuildingList = new List<BuildingController>();	

	private void Awake()
	{

	}

	/// <summary>
	/// Called when a Building is selected with a mouse click
	/// </summary>
	public void ClickSelectBuilding(BuildingController newBuilding)
	{
		// Remove all Buildings selected in the zone
		DeselectAll();
		SelectBuilding(newBuilding);
	}
	
	/// <summary>
	/// Invoked when selecting a Building with Shift+mouse click
	/// </summary>
	public void ShiftClickSelectBuilding(BuildingController newBuilding)
	{
		// If you select a previously selected unit
		if ( selectedBuildingList.Contains(newBuilding) )
		{
			DeselectBuilding(newBuilding);
		}
		// If you choose a new Building
		else
		{
			SelectBuilding(newBuilding);
		}
	}

	/// <summary>
	/// Called when selecting a Building by mouse dragging
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
	/// Called when all Buildings are deselected
	/// </summary>
	public void DeselectAll()
	{
		for ( int i = 0; i < selectedBuildingList.Count; ++i)
		{
			selectedBuildingList[i].DeselectBuilding();
		}
		selectedBuildingList.Clear();
	}

	/// <summary>
	/// NewBuilding selection set received as a parameter
	/// </summary>
	private void SelectBuilding(BuildingController newBuilding)
	{
		// Method to be called when a Building is selected
		newBuilding.SelectBuilding();
		// Save the selected Building information to the list
		selectedBuildingList.Add(newBuilding);
	}
	
	/// <summary>
	/// Set deselection of new Building received as a parameter
	/// </summary>
	private void DeselectBuilding(BuildingController newBuilding)
	{
		// Method called when Building is released
		newBuilding.DeselectBuilding();
		// Delete the selected Building information from the list
		selectedBuildingList.Remove(newBuilding);
	}
}
