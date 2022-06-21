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
        
    }

    protected override void Update()
    {
        base.Update();

        if(isSelected && isActive)
        {
            StartCoroutine(MineSugar());
        }
    }

    IEnumerator MineSugar()
    {
        cost[0] += sugarPerSec;   
        yield return new WaitForSeconds(1f);
    }
}
