using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    protected float hp;
    public float damage { get; set; }
    protected float attackSpeed;
    protected float attackRange;
    protected float returnExp;
    protected float eyeSight;
    protected float cose;
    protected float dropItem;
    [SerializeField] protected TextAsset dataFile;
    [SerializeField] protected Data.Stat stat;
    protected virtual void DataLoad(string fileName)
    {
        dataFile = Resources.Load(fileName) as TextAsset;
        stat = new Data.Stat();

        stat = JsonUtility.FromJson<Data.Stat>(dataFile.text);

        hp = stat.hp;
        damage = stat.damage;
        attackRange = stat.attackRange;
        attackSpeed = stat.attackSpeed;
    }
    public virtual void Hit(float hitDamage)
    {
        hp -= hitDamage;
        Die();
    }

    protected virtual void Die()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
