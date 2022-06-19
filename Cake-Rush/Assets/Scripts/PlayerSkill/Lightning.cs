using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SkillBase
{
    [SerializeField] private float[] damage;

    protected override void Awake()
    {
        skillEffect = Resources.Load<GameObject>("Effect/Skill/Lightning");
        maxSkillLevel = 3;
        //skillRangeObj = Resources.Load<GameObject>("Rangeview/LightningView");
    }

    public void UseSkill(int skillLevel, Collider unit)
    {
        if (!skillStat[skillLevel].isCoolTime && isSkillable == true)
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
        unit = unit as T;
        unit.Hit(unit.curHp / 100 * damage[level]);
    }
}