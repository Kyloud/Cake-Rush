using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Character and Building GameObject's Base Class
public class EntityBase : MonoBehaviour
{
    #region  element
    public float damage { get; set; }
    public float maxHp { get; set; }
    public float curHp { get; set; }
    protected float attackSpeed;
    protected float attackRange;
    protected float criticalChance;
    protected float criticalDamage;
    protected float returnExp;
    protected float eyeSight;
    protected int[] cost = new int[3];
    protected int[] dropCost = new int[3];
    protected float defensive;
    protected float spawnTime;
    public float moveSpeed { get; set; }
    protected Data.Stat stat;
    public GameObject Marker;
    #endregion

    protected virtual void Awake()
    {
        Marker = transform.Find("Marker").gameObject;
        Init();
    }

    protected virtual void Init()
    {
        maxHp = stat.hp;
        curHp = stat.hp;
        damage = stat.damage;
        attackRange = stat.attackRange;
        attackSpeed = stat.attackSpeed;
        returnExp = stat.returnExp;
        eyeSight = stat.eyeSight;
        cost = stat.cost;
        dropCost = stat.dropCost;
        defensive = stat.defensive;
        spawnTime = stat.spawnTime;
        moveSpeed = stat.moveSpeed;
    }

    #region function
    public virtual void Hit(float hitDamage)
    {
        //Debug.Log($"Hit({hitDamage}, at {gameObject.name})");
        curHp -= hitDamage;

        if(curHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"Die(), at {gameObject.name})");
    }

    protected void DataLoad (string fileName)
    {
        Debug.Log($"DataLoaded!({fileName}), at {gameObject.name})");
        stat = new Data.Stat();
        TextAsset dataFile = Resources.Load<TextAsset>($"Data/{fileName}");
        stat = JsonUtility.FromJson<Data.Stat>(dataFile.text);
    }

    
    #endregion
}
