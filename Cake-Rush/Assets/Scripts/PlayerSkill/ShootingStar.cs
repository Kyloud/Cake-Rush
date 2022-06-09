using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShootingStar : SkillBase
{
    public float stunTime;
    private bool isColision;
    private float angleRange;

    private void Awake()
    {
        range = 5f;
        angleRange = 45f;
    }

    public void UseSkill(int skillLevel, Collider[] colliders)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            SectorColision(colliders);
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }

    //매개변수 배열 전달 말고 하나씩 전달
    public void SectorColision(Collider[] colliders)
    {
        Transform target;
        Vector3 dirction;
        float dotValue = 0;

        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));

        for(int i = 0; i < colliders.Length; i++)
        {
            dirction = colliders[i].transform.position - transform.position;

            if(Vector3.Dot(dirction.normalized, transform.forward) > dotValue)
            {
                StunEntity(colliders[i].GetComponent<CharacterBase>());
            }
        }
    }

    private void StunEntity<T>(T unit) where T : CharacterBase
    {
        unit = unit as T;

        unit.Stun(stunTime);
        Debug.Log("Stun");
    }
}
