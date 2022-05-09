using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
	RTSUnitController rtsUnitController;
	[SerializeField]
	private	GameObject[] unitPrefab = new GameObject[2];
	[SerializeField]
	private	int	maxUnitCount;

	private	Vector2	minSize = new Vector2(-22, -22);
	private	Vector2	maxSize = new Vector2(22, 22);
	public Queue<UnitController> spawnQueue = new Queue<UnitController>();

	private bool isRunning = false;
	
	void Awake()
	{
		rtsUnitController = GameObject.FindWithTag("GameController").GetComponent<RTSUnitController>();
	}

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

	public IEnumerator SpawnUnits(int unitNumber)
	{
		GameObject clone = unitPrefab[unitNumber];
		UnitController unit = clone.GetComponent<UnitController>();
		spawnQueue.Enqueue(unit);
		yield return new WaitForSeconds(2f);
		spawnQueue.Dequeue();
		rtsUnitController.UnitList.Add(unit);	
		Instantiate(clone, transform.position + Vector3.forward * 3, Quaternion.identity);
	}
}