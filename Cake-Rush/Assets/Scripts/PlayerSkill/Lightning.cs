using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SkillBase
{
    public float[] damage;

    public void UseSkill(int skillLevel, CharacterBase unit)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            Debug.Log("³«·Ú");
            Factor(unit);
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }

    private void Factor<T>(T unit) where T : CharacterBase
    {
        if(unit.GetType() != typeof(PlayerController))
        {
            unit = unit as T;
            unit.GetComponent<CharacterBase>().Hit(damage[level]);
        }
    }
}