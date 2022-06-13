using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeShot : SkillBase
{
    public float currentHoldTime { get; set; }

    private float skillHoldTime = 2.5f;
    private const float DELAY = 0.25f;
    private WaitForSeconds delayTime;

    [SerializeField] private float[] damage;

    private void Awake()
    {
        delayTime = new WaitForSeconds(DELAY);
    }

    public void UseSkill(int skillLevel, Collider[] colliders)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            currentHoldTime = skillHoldTime;
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }
}

