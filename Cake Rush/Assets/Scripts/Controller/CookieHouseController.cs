using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieHouseController : BuildController
{
    [SerializeField] private GameObject[] units = new GameObject[4];
    
    protected override void Awake()
    {
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
        }
    }

    void SpwanUnit()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Spawn(0));
            return;
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Spawn(1));
            return;
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(Spawn(2));
            return;
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(Spawn(3));
        }
    }

    IEnumerator Spawn(int i)
    {
        yield return new WaitForSecondsRealtime(2f);
        GameObject newUnit = Instantiate(units[i], transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f)), Quaternion.identity);
        rtsController.unitList.Add(newUnit.GetComponent<UnitController>());    
    }
}
