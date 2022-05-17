using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SkillStat
{
    public float level { get; set; }
    public float coolDown { get; set; }
    public float factor { get; set; }
}

public class PlayerController : UnitController
{
    public float buildRange { get; set;}

    private SkillStat Skill_CakeRush;
    private SkillStat Skill_Lightning;
    protected override void Awake()
    {
        Skill_CakeRush = new SkillStat();
        Skill_Lightning = new SkillStat();
        base.Awake();
    }

    private void CakeRush()
    {
        
    }

    private void Lightning()
    {

    }

    public override void Move(Vector3 destination)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Move(hit.transform.position);
            }
            else
            {
                Attack();
            }
        }
    }

    protected override void Attack()
    {
        
    }

    protected override void Stop()
    {

    }

    
}
