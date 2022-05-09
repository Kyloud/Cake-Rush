using UnityEngine;

public class MouseDrag: MonoBehaviour
{
	[SerializeField]
	private	RectTransform dragRectangle;			// RectTransform of Image UI to visualize the range dragged with the mouse

	private	Rect dragRect;				// Range dragged with the mouse (xMin~xMax, yMin~yMax)
	private	Vector2	start = Vector2.zero;	// drag start position
	private	Vector2	end = Vector2.zero;		// drag end position
	
	private	Camera mainCamera;
	private	RTSUnitController rtsUnitController;

	private void Awake()
	{
		mainCamera = Camera.main;
		rtsUnitController = GetComponent<RTSUnitController>();
		
		// Set the image size to (0, 0) with start and end set to (0, 0) to make it invisible on the screen
		DrawDragRectangle();
	}

	private void Update()
	{
		if ( Input.GetMouseButtonDown(0) )
		{
			start	 = Input.mousePosition;
			dragRect = new Rect();
		}
		
		if ( Input.GetMouseButton(0) )
		{
			end = Input.mousePosition;
			
			// Represents the drag range as an image while dragging with the mouse clicked
			DrawDragRectangle();
		}

		if ( Input.GetMouseButtonUp(0) )
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
		// 모든 유닛을 검사
		foreach (UnitController unit in rtsUnitController.UnitList)
		{
			// Converts the unit's world coordinates to screen coordinates to check if they are within the drag range
			if ( dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)) )
			{
				rtsUnitController.DragSelectUnit(unit);
			}
		}
	}
}

