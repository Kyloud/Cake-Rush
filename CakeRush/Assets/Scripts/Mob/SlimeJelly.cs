using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJelly : EntityBase
{
    protected override void Awake()
    {
        base.DataLoad("Data/SlimeJelly");
        hp = stat.hp;
    }
}
