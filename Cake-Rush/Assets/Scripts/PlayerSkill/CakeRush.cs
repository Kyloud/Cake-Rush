using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRush : SkillBase
{
    protected override void Awake()
    {
        skillEffect = Resources.Load<GameObject>("Effect/Skill/CakeRush");
    }

    public void UnitCakeRush(int skillLevel, Transform unit)
    {
        Debug.Log($"Cake Rush! | Level {skillLevel}");
        GameObject go = Instantiate(skillEffect, unit.transform.position, Quaternion.Euler(-90, 0, 0));
        go.transform.parent = unit;
    }


    public void UseSkill(int skillLevel)
    {
        if(!skillStat[skillLevel].isCoolTime)
        {
            for(int i = 0; i < GameManager.instance.rtsController.unitList.Count; i++)
            {
                GameManager.instance.rtsController.unitList[i].cakeRush.UnitCakeRush(skillLevel, GameManager.instance.rtsController.unitList[i].transform);
            }

            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }
}
