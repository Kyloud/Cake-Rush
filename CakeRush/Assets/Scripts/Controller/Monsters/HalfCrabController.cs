using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfCrabController : MobController
{
    protected override void Awake()
    {
        DataLoad("HalfCrab");     
        base.Awake();
        navMashAgent.speed = moveSpeed;
    }

    protected override void Update()
    {
        base.Update();
    }
}
