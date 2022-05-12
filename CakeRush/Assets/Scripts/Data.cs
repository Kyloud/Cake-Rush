using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //Structure for initialization of entity stats

    [SerializeField]    
    public struct Stat
    {
<<<<<<< HEAD
        public float hp { get; set; }
        public float damage { get; set; }
        public float moveSpeed { get; set; }
        public float attackRange { get; set; }
        public float attackSpeed { get; set; }

        
        public Stat(float hp, float damage, float moveSpeed, float attackRange, float attackSpeed)
        {
            this.hp = hp;
            this.damage = damage;
            this.moveSpeed = moveSpeed;
            this.attackRange = attackRange;
            this.attackSpeed = attackSpeed;
        }
=======
        public float hp;
        public float damage;
        public float moveSpeed;
        public float attackRange;
        public float attackSpeed; 
>>>>>>> BiN_
    }
}
