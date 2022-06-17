using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateMinerController : BuildBase
{    
    private int ChocolatePerSec = 3;
    
    protected override void Awake()
    {
        isSpawned = true;
        DataLoad("ChocolateMiner"); 
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
            MineChocolate();
        }
    }

    IEnumerator MineChocolate()
    {
        cost[2] += ChocolatePerSec;   
        yield return new WaitForSeconds(1f);
    }
}
