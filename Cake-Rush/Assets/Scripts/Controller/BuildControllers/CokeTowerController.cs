using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeTowerController : BuildBase
{

    protected override void Awake()
    {
        isSpawnable = false;
        DataLoad("CokeTower"); 
        base.Awake();
    }

    void Start()
    {
        StartCoroutine(FindTarget());
    }

    protected override void Update()
    {
        base.Update();

        if(isSelected && isActive)
        {
               
        }
    }

    //[SerializeField] private List<Collider> enemies = new List<Collider>();
    [SerializeField] private Collider[] enemies;
    IEnumerator FindTarget()
    {
        while(true)
        {
            enemies = Physics.OverlapSphere(transform.position, 30, GameProgress.instance.selectableLayer);
            float minDistance = 999999f;
            Collider target = null;
            foreach(Collider enemy in enemies)
            {
                enemy.gameObject.GetComponent<EntityBase>().Hit(damage);
                if((enemy.transform.position - transform.position).magnitude <= minDistance)
                {
                    minDistance = (enemy.transform.position - transform.position).magnitude;
                    target = enemy;
                }
            }   
                if(target != null) // attack
                {
                    yield return new WaitForSeconds(0.5f);
                    target.gameObject.GetComponent<EntityBase>().Hit(damage);
                    Debug.Log($"{target.gameObject.name}");
                }
                
                yield return new WaitForSeconds(attackSpeed);
        } 
    }
}