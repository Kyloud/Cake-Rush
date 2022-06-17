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
    Vector3 pos;
    private void Awake()
    {
        delayTime = new WaitForSeconds(DELAY);
    }

    public override void UseSkill(int skillLevel, Vector3 point)
    {
        if (!skillStat[skillLevel].isCoolTime)
        {
            Debug.Log("Check");
            pos = point;
            StartCoroutine(skillStat[skillLevel].CurrentCoolTime());
        }
        else
        {
            return;
        }

        currentHoldTime = skillHoldTime;
        StartCoroutine(SkillActive(point));
    }

    private IEnumerator SkillActive(Vector3 point)
    {
        GameObject temp = Instantiate(skillEffect, point, Quaternion.Euler(0, 1, 0));

        while (currentHoldTime >= 0)
        {
            Collider[] overlapShpere = Physics.OverlapSphere(point, radius, GameProgress.instance.selectableLayer);
            
            Factor(overlapShpere);
            currentHoldTime -= DELAY;

            yield return delayTime;
        }

        Destroy(temp);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pos, 4f);
    }
}

