using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모든 캐릭터와 건물의 최상위 부모 클래스
public class EntityBase : MonoBehaviour
{
    #region  element
    public float damage;
    protected float hp;
    protected float attackSpeed;
    protected float attackRange;
    protected float retuenExp;
    protected float eyeSight;
    protected int[] cost = new int[3];
    protected int[] dropCost = new int[3];
    protected float defensive;
    protected float spwanTime;
    protected float moveSpeed;
    protected Data.Stat stat;
    protected TextAsset dataFile;
    public GameObject Marker;
    #endregion

    #region function
    public virtual void Hit(float hitDamage)
    {
        Debug.Log($"Hit({hitDamage}, at {gameObject.name})");
        hp -= hitDamage;
        if(hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log($"Die(), at {gameObject.name})");
        
    }

    protected void DataLoad ( string fileName )
    {
        Debug.Log($"DataLoaded!({fileName}), at {gameObject.name})");
    }

    
    #endregion
}