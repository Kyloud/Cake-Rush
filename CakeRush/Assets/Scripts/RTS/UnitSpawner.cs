using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
	[SerializeField]
	private	GameObject[] unitPrefab = new GameObject[2];
	[SerializeField]
	private	int	maxUnitCount;

	private	Vector2	minSize = new Vector2(-22, -22);
	private	Vector2	maxSize = new Vector2(22, 22);
	public Queue<UnitController> asdfas = new Queue<UnitController>();
	
	// public List<UnitController> SpawnUnits()
	// {
	// 	List<UnitController> unitList = new List<UnitController>(maxUnitCount);

	// 	for ( int i = 0; i < maxUnitCount; ++ i )
	// 	{
	// 		Vector3 position = new Vector3(Random.Range(minSize.x, maxSize.x), 1, Random.Range(minSize.y, maxSize.y));

	// 		GameObject clone = Instantiate(unitPrefab, position, Quaternion.identity);
	// 		UnitController unit = clone.GetComponent<UnitController>();

	// 		unitList.Add(unit);
	// 	}

	// 	return unitList;
	// }

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			SpawnUnits();
		}
	}

	public void SpawnUnits()
	{
		GameObject clone = Instantiate(unitPrefab[1], transform.position + Vector3.forward * 3, Quaternion.identity);
		UnitController unit = clone.GetComponent<UnitController>();
		
	}

}