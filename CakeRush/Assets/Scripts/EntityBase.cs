using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityBase : ObjectBase
{
    protected float defensive;
    protected float spawnTime;
    protected float moveSpeed;

    NavMeshAgent agent;
    
    protected virtual void EntityInit()
    {

    }
}
