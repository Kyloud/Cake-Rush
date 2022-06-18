using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SkillBase
{
    public float[] damage;
    protected override void Awake()
    {
        skillEffect = Resources.Load<GameObject>("Effect/Skill/Lightning");
    }

    public void UseSkill(int skillLevel, Collider unit)
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
        Instantiate(skillEffect, unit.transform.position, Quaternion.Euler(-90, 0, 0));
        Factor(unit.GetComponent<CharacterBase>());
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