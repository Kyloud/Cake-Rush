using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityBase : ObjectBase
{
    protected float defensive;
    protected float spawnTime;
    protected float moveSpeed;

    protected NavMeshAgent navMeshAgent;

    protected virtual void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start() 
    { }

    public override void Hit(float hitDamage)
    {
        base.Hit(hitDamage);
    }

    protected override void Die()
    {
        base.Die();
    }
}
