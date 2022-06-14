using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeShot : SkillBase
{
    public float currentHoldTime { get; set; }
    public float radius { get; set; }
    private const float skillHoldTime = 10f;
    private const float DELAY = 1f;
    private WaitForSeconds delayTime;

    [SerializeField] private float[] damage;

    private void Awake()
    {
        delayTime = new WaitForSeconds(DELAY);
    }

    public void UseSkill(int skillLevel, Vector3 point)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            currentHoldTime = skillHoldTime;
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }

    private IEnumerator SkillActive(Transform point)
    {
        while(currentHoldTime >= 0)
        {
            Collider[] overlapShpere = Physics.OverlapSphere(point.position, radius, GameProgress.instance.selectableLayer);

            currentHoldTime -= DELAY;
            yield return delayTime;
        }
    }

    private void Factor(Collider[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<CharacterBase>().Hit(damage[level]);
        }
    }
}

