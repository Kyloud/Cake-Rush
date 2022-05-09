using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public struct Stat
    {
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
    }
}
