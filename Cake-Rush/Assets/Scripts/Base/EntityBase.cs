using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Character and Building GameObject's Base Class
public class EntityBase : MonoBehaviourPunCallbacks
{
    #region  element
    public float damage { get; set; }
    public float maxHp { get; set; }
    [SerializeField] public float curHp;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float criticalChance;
    [SerializeField] protected float criticalDamage;
    [SerializeField] protected float returnExp;
    [SerializeField] protected float eyeSight;
    [SerializeField] protected int[] cost = new int[3];
    [SerializeField] protected int[] dropCost = new int[3];
    [SerializeField] protected float defensive;
    [SerializeField] protected float spawnTime;
    [SerializeField] public float moveSpeed { get; set; }
    [SerializeField] protected Data.Stat stat;
    protected RTSController rtsController;
    [SerializeField] public GameObject Marker;
    public bool isSelected;
    public bool isActive;
    #endregion

    protected virtual void Awake()
    {
        Marker = transform.Find("Marker").gameObject;
        rtsController = GameObject.Find("RTSManager").GetComponent<RTSController>();
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
        stat = new Data.Stat();
        TextAsset dataFile = Resources.Load<TextAsset>($"Data/{fileName}");
        stat = JsonUtility.FromJson<Data.Stat>(dataFile.text);
    }
    public void Select()
	{
        isSelected = true;
		Marker.SetActive(true);
	}
    
	public void Deselect()
	{
        isSelected = false;
        Marker.SetActive(false);
	}
    
    protected virtual void Update()
    {

    }
    
    #endregion
}
