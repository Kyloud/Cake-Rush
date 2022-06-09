using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : SkillBase
{
    public float stunTime;

    public override void UseSkill(int skillLevel)
    {
        float distance;

        if (!skillStat[skillLevel].isCoolTime)
        {
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }
}
