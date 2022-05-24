using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorypongCandyController : MobController
{
    protected override void Awake()
    {
        DataLoad("JorypongCandy"); 
        base.Awake();
        navMashAgent.speed = moveSpeed;
    }

    protected override void Update()
    {
        base.Update();
    }

}
