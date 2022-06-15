using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : SkillBase
{
    public float stunTime { get; set; }
    private float angleRange;

    private void Awake()
    {
        angleRange = 60f;
    }

    public override void UseSkill(int skillLevel, Collider[] colliders)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            StopAllCoroutines();

            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());

            if (colliders.Length < 2)
            {
                return;
            }

            SectorColision(colliders);
        }
        else
        {
            return;
        }
    }

    public void SectorColision(Collider[] colliders)
    {
        Vector3 dirction;
        float dotValue;

        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));

        for(int i = 0; i < colliders.Length; i++)
        {
            dirction = colliders[i].transform.position - transform.position;

            if(Vector3.Dot(dirction.normalized, transform.forward) > dotValue && colliders[i].GetType() != typeof(PlayerController))
            {
                StunEntity(colliders[i].gameObject.GetComponent<CharacterBase>());
            }
        }
    }

    private void StunEntity<T>(T unit) where T : CharacterBase
    {
        unit = unit as T;

        StartCoroutine(unit.Stun(stunTime));
    }
}
