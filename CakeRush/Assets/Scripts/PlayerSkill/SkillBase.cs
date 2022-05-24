using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillStat
{
    public float coolDown;          //Cool time   
    public float currentCoolDown;   //Current cool time
    public bool isCoolDown;         //Is the current skill available?

    public IEnumerator CurrentCoolDown()
    {
        isCoolDown = true;

        while(currentCoolDown >= 0)
        {
            currentCoolDown -= Time.deltaTime;

            yield return null;
        }

        isCoolDown = false;
    }
}

public class SkillBase : MonoBehaviour
{
    [SerializeField] protected SkillStat[] skillStat;
    [SerializeField] protected float[] damage;
    protected float range;
    public int skillLevel { get; set; }

    public virtual void UseSkill(int skillLevel)
    {
        if(skillStat[skillLevel].isCoolDown)
        {
            StartCoroutine(skillStat[skillLevel].CurrentCoolDown());
        }
        else
        {
            return;
        }
    }
}
