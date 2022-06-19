using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//모든 캐릭터의 최상위 부모 클래스
public class CharacterBase : EntityBase
{
    public NavMeshAgent navMashAgent;
    protected Animator animator;
    float curStunTime;
    protected bool isStun;

    protected override void Awake()
    {
        isStun = false;
        navMashAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        base.Awake();
    }
    
    protected override void Update()
    {
        if(isStun) return;
        base.Update();
    }

    public IEnumerator Stun(float stunTime)
    {
        isStun = true;
        curStunTime = stunTime;
        Debug.Log($"Stun {gameObject.name}");

        while(curStunTime >= 0)
        {
            curStunTime -= Time.deltaTime;
            yield return null;
        }

        curStunTime = 0;
        isStun = false;
    }
}