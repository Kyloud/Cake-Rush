using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarMinerController : BuildBase
{
    private int sugarPerSec = 3;

    protected override void Awake()
    {
        isSpawnable = true;
        DataLoad("SugarMiner"); 
        base.Awake();
    }

    void Start()
    {
        StartCoroutine(MineSugar());
    }

    protected override void Update()
    {
        base.Update();

    }

    IEnumerator MineSugar()
    {
        yield return new WaitUntil(()=> isActive == true);
        while(true)
        {
            rtsController.cost[0] += sugarPerSec;   
            yield return new WaitForSeconds(1f);
            Debug.Log(rtsController.cost[0]);
            yield return null;
        }
    }
}
