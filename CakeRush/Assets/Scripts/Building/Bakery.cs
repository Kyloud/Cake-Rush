using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakery : BuildBase
{
    UnitSpawner spawner;

    void Start()
    {
        spawner = gameObject.GetComponent<UnitSpawner>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            Spawn(0);
        else if(Input.GetKeyDown(KeyCode.W))
            Spawn(1);
        else if(Input.GetKeyDown(KeyCode.E))
            Spawn(2);
        else if(Input.GetKeyDown(KeyCode.R))
            Spawn(3);
    }

    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Spawn(int num)
    {
        StartCoroutine(spawner.SpawnUnits(num));
    }
}
