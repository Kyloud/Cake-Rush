using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SkillBase
{
    [SerializeField] private float[] damage;

    protected override void Awake()
    {
        skillEffect = Resources.Load<GameObject>("Effect/Skill/Lightning");
        rangeView = Resources.Load<GameObject>("Prefabs/RangeView/Lightning");
        maxSkillLevel = 2;
        base.Awake();

        
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
        
        Factor(unit.GetComponent<CharacterBase>());
    }

    private void Factor<T>(T unit) where T : CharacterBase
    {
        unit = unit as T;
        Instantiate(skillEffect, unit.transform.position, Quaternion.Euler(-90, 0, 0));
        unit.Hit(unit.curHp / 100 * damage[level]);
    }
}