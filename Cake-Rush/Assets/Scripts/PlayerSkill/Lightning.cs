using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SkillBase
{
    public override void UseSkill(int skillLevel)
    {
        Debug.Log("����");

        if (!skillStat[skillLevel].isCoolTime)
        {
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }

    private void Factor<T>(T unit) where T : CharacterBase
    {

    }
}