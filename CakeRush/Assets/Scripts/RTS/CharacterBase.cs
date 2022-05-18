using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//모든 캐릭터의 최상위 부모 클래스
public class CharacterBase : EntityBase
{
    protected NavMeshAgent navMashAgent;
    float curStunTime;

    protected override void Awake()
    {
        navMashAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Stun()
    {
        curStunTime -= Time.deltaTime;
    }
}