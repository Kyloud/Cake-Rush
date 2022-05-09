using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Stat
{
    public float moveSpeed { get; set; }
    public float attackRange { get; set; }
    public float attackSpeed { get; set; }

    public Stat(float moveSpeed, float attackRange, float attackSpeed)
    {
        this.moveSpeed = moveSpeed;
        this.attackRange = attackRange;
        this.attackSpeed = attackSpeed;
    }
}

public class PlayerController : MonoBehaviour   
{   
    private PlayerMovement playerMovement;
    public Stat stat;
    private void Awake()
    {
        stat = new Stat(5, 5, 1);
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.OverridingState(stat.moveSpeed, stat.attackRange, stat.attackSpeed);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
                {
                    StartCoroutine(playerMovement.OutToAttakRange(hit.transform.position, stat.attackRange));
                }
                else
                {
                    playerMovement.MoveTo(hit.point);
                    Debug.Log("Checked Click");
                }

                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}
