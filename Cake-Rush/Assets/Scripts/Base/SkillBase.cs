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

        while (currentCoolTime >= 0)
        {
            currentCoolTime -= Time.deltaTime;

            yield return null;
        }

        Debug.Log("CoolTime");

        Debug.Log(isCoolTime);

        isCoolTime = false;
        currentCoolTime = 0;
    }
}

public class SkillBase : MonoBehaviour
{
    [SerializeField] protected SkillStat[] skillStat;

    public float range { get; set; }
    public int level { get; set; }

    public virtual void UseSkill(int skillLevel, Vector3 point)
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
}
