using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeShot : SkillBase
{
    public float radius { get; set; }

    private const float skillHoldTime = 10f;
    private const float DELAY = 4f;
    private float currentHoldTime;
    private WaitForSeconds delayTime;

    [SerializeField] private float[] damage;

    private void Awake()
    {
        delayTime = new WaitForSeconds(DELAY);
    }

    public override void UseSkill(int skillLevel, Vector3 point)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            currentHoldTime = skillHoldTime;
            StartCoroutine(SkillActive(point));
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }
    }

    private IEnumerator SkillActive(Vector3 point)
    {
        while(currentHoldTime >= 0)
        {
            Collider[] overlapShpere = Physics.OverlapSphere(point, radius, GameProgress.instance.selectableLayer);
            
            Factor(overlapShpere);
            currentHoldTime -= DELAY;

            yield return delayTime;
        }
    }

    private void Factor (Collider[] colliders)
    {
        if(colliders.Length < 1)
        {
            return;
        }

        for(int i = 0; i < colliders.Length; i++)
        {
            Debug.Log($"{colliders[i].name} Coke Shot");
            colliders[i].GetComponent<CharacterBase>().Hit(damage[level]);
        }
    }
}

