using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieHouseController : BuildBase
{

    [SerializeField] private GameObject[] units = new GameObject[4];
    
    Vector3 collectionPos;
    protected override void Awake()
    {
        collectionPos = new Vector3(transform.position.x, 0f, transform.position.z);
        isSpawnable = true;
        DataLoad("CookieHouse"); 
        base.Awake();
    }

    void Start()
    {

    }

    protected override void Update()
    {
        base.Update();

        if(isSelected && isActive)
        {
            SpwanUnit();
            CollectionUnit();
        }
    }

    void CollectionUnit()
    {
        if ( Input.GetMouseButtonDown(1))
		{
			Ray	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// When there is an object hitting the ray (= clicking on the unit)
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, GameProgress.instance.groundLayer))
			{
				collectionPos = hit.point;
			}
        }
    }

    void SpwanUnit()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Spawn(0));
            return;
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Spawn(1));
            return;
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Spawn(2));
            return;
        }
        else if(Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(Spawn(3));
        }
    }

    IEnumerator Spawn(int n)
    {
        EntityBase unit = units[n].GetComponent<EntityBase>();
        yield return new WaitForSeconds(unit.spawnTime);
        Debug.Log($"prevCost: {rtsController.cost[0]} {rtsController.cost[1]} {rtsController.cost[2]}");

        GameObject newUnit = Instantiate(units[n], transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f)), Quaternion.identity);
        newUnit.GetComponent<UnitBase>().Move(collectionPos);
        for(int i = 0; n < 3; n++)
        {
            rtsController.cost[i] -= unit.cost[i];
        }
        
        Debug.Log($"curCost: {rtsController.cost[0]} {rtsController.cost[1]} {rtsController.cost[2]}");
        rtsController.unitList.Add(newUnit.GetComponent<UnitBase>());    
    }
}
