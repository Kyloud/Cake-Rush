using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeShot : SkillBase
{
    public override void UseSkill(int skillLevel)
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

    public void SetActivation()
    {
        gameObject.SetActive(false);
    } 

    private IEnumerator Factor <T> (T component) where T : CharacterBase
    {
        T data = component as T;

        data.Hit(damage[skillLevel]);

        yield return new WaitForEndOfFrame();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Charactor") || other.gameObject.layer == LayerMask.NameToLayer("Selectable"))
        {
            StartCoroutine(Factor <CharacterBase> (other.gameObject.GetComponent<CharacterBase>()));        
        }    
    }
}
