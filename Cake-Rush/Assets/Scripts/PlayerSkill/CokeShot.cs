using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeShot : SkillBase
{
    [SerializeField] private float[] damage;

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
            StartCoroutine(Factor(other.gameObject.GetComponent<UnitBase>()));        
        }
    }
}
