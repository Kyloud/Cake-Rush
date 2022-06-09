using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRush : SkillBase
{
    public void UnitCakeRush(int skillLevel)
    {
        Debug.Log($"Cake Rush! | Level {skillLevel}");
    }

    public override void UseSkill(int skillLevel)
    {
        if(!skillStat[skillLevel].isCoolTime)
        {
            Debug.Log("Cake Rush");
            for (int i = 0; i < GameManager.instance.rtsController.unitList.Count; i++)
            {
                GameManager.instance.rtsController.unitList[i].cakeRush.UnitCakeRush(skillLevel);
            }

            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }
}
