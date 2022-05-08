using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakery : BuildBase
{
    UnitSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponentInParent<UnitSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            Spawn(0);
        else if(Input.GetKeyDown(KeyCode.W))
            Spawn(1);
        else if(Input.GetKeyDown(KeyCode.A))
            Spawn(2);
        else if(Input.GetKeyDown(KeyCode.S))
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
