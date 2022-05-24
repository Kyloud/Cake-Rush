using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifRatController : MobController
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        DataLoad("TheifRat");
        base.Awake();        
        navMashAgent.speed = moveSpeed;
    }
    void Start()
    {
        
    }

}
