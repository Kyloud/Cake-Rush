using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //Structure for initialization of entity stats

    [SerializeField]    
    public struct Stat
    {
       public float hp;
        public float damage;
        public float moveSpeed;
        public float attackRange;
        public float attackSpeed; 
    }
}
