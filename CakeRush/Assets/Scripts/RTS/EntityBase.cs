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
    protected float criticalChance;
    protected float criticalDamage;
    protected float retuenExp;
    protected float eyeSight;
    protected int[] cost = new int[3];
    protected int[] dropCost = new int[3];
    protected int dropExp;
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

    }

    public virtual void Die()
    {

    }

    protected void DataLoad ( string fileName )
    {
        
    }
    #endregion
}