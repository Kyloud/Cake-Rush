using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusController : BuildBase
{

    protected override void Awake()
    {
        isSpawned = false;
        DataLoad("Nexus"); 
        base.Awake();
    }


    protected override void Update()
    {
        
    }
}
