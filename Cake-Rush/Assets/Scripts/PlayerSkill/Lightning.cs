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
            Debug.Log("Check");
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }

        Debug.Log("³«·Ú");
        Factor(unit);
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