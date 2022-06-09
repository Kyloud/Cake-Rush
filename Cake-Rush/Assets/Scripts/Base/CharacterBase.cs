using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//모든 캐릭터의 최상위 부모 클래스
public class CharacterBase : EntityBase
{
    protected NavMeshAgent navMashAgent;
    protected Animator animator;
    float curStunTime;

    protected override void Awake()
    {
        navMashAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        base.Awake();
    }
    
    /*protected override void Update()
    {
        base.Update();
    }*/

    public IEnumerator Stun(float stunTime)
    {
        curStunTime = stunTime;

        while(curStunTime >= 0)
        {
            curStunTime -= Time.deltaTime;
            yield return null;
        }
    }
}