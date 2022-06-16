using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : SkillBase
{
    public float stunTime { get; set; }
    private float angleRange;
    [SerializeField] private Transform skill;
    private void Awake()
    {
        angleRange = 60f;
    }

    public void UseSkill(int skillLevel, Vector3 point)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            Debug.Log("Check");
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }

        //StopAllCoroutines();
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0f, GameProgress.instance.selectableLayer);

        point.y -= 60;

        for (int i = -30; i <= 30; i += 10)
        {
            Instantiate(skillEffect, skill.position, Quaternion.Euler(0, point.y - i, 0));
        }

        if (colliders.Length < 2)
        {
            return;
        }

        SectorColision(colliders);
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
