using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSnackController : UnitController
{
    protected override void Awake()
    {
        DataLoad("StoneSnack"); 
        base.Awake();      
        navMashAgent.speed = moveSpeed;
        gameObject.GetComponent<FieldOfView>().viewRadius = eyeSight;
    }

    protected override void Update()
    {
        base.Update();
    }
}
