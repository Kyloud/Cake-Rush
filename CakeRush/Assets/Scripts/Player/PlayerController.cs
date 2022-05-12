using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{   
    [SerializeField] private GameObject lightningObject;
    [SerializeField] private LayerMask entityLayer;
    
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
                {
                    StartCoroutine(OutToAttakRange(hit.transform.position, stat.attackRange));
                }
                else
                {
                    MoveTo(hit.point);
                    Debug.Log("Checked Click");
                }

                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            }
        }
    }
    protected override void DataLoad(string fileName)
    {
        base.DataLoad(fileName);
    }
    
    //Skill lightning
    public void Lightning(float damage)
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


    //Skill Cakerush
    public void CakeRush(UnitController unit)
    {
        
    }
    
    public override void MoveTo(Vector3 end)
    {
        base.MoveTo(end);
    }

    public override IEnumerator OutToAttakRange(Vector3 unitPosition, float range)
    {
        return base.OutToAttakRange(unitPosition, range);
    }
}
