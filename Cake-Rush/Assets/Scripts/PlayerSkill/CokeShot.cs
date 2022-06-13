using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeShot : SkillBase
{
    [SerializeField] private float[] damage;

    public override void UseSkill(int skillLevel)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }

    private IEnumerator Factor <T> (T component) where T : CharacterBase
    {
        T data = component as T;

        data.Hit(damage[skillLevel]);

        yield return new WaitForEndOfFrame();
    }
}
