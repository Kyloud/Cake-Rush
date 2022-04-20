using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //����
    protected float hp;
    protected float attackSpeed;
    protected float attackRange;
    public float damage { get; set; }

    //�þ� �� ��ȣ�ۿ�
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
