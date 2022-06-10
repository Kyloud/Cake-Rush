using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillStat
{
    public float coolTime;          //Cool time   
    public float currentCoolTime;   //Current cool time
    public bool isCoolTime;         //Is the current skill available?

    public IEnumerator CurrentCoolTime()
    {
        isCoolTime = true;

        currentCoolTime = coolTime;

        Debug.Log(isCoolTime);

        while(currentCoolTime >= 0)
        {
            currentCoolTime -= Time.deltaTime;

            yield return null;
        }

        Debug.Log("CoolTime");

        Debug.Log(isCoolTime);

        isCoolTime = false;
        currentCoolTime = 0;
    }

    //예상 버그 : 스킬 사용후 레벨업시 스킬 쿨이 초기화됌.
    //해결법 -> 레벨업시 이전 쿨타임 데이터를 레벨업 후 쿨타임 데이터로 옮김.
    //ex ) skillStat[skillLevel].currentCoolTime = skillStat[skillLevel - 1].currentCoolTime
}

public class SkillBase : MonoBehaviour
{
    [SerializeField] protected SkillStat[] skillStat;
    [SerializeField] protected float[] damage;

    public float range { get; set; }
    public int skillLevel { get; set; }

    public virtual void UseSkill(int skillLevel)
    {
        if(!skillStat[skillLevel].isCoolTime)
        {
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }
}
