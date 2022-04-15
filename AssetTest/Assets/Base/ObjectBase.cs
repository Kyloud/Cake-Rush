using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //스탯
    protected float hp;
    protected float attackSpeed;
    protected float attackRange;
    public float damage { get; set; }

    //시야 및 상호작용
    protected float returnExp;
    protected float eyeSight;
    protected float cose;
    protected float dropItem;

    protected virtual void Attack()
    {

    }

    protected virtual void Hit(float hitDamage)
    {
        hp -= hitDamage;
    }

    protected virtual void Die()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
