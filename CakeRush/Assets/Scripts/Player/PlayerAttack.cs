using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : EntityBase
{
    [SerializeField] private GameObject lightningObject;
    [SerializeField] private LayerMask entityLayer;
    public void LightningStrlike(float damage)
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, entityLayer))
            {
                hit.transform.GetComponent<EntityBase>().Hit(damage);
            }
        }
    }

    public void CakeRush()
    {

    }

    public void BasicAttack()
    {
        Debug.Log("Attack");
    }
}
