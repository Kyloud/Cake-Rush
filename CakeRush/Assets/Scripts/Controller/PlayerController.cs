using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillStat
{
    public float coolDown;    
    public float currentCoolDown;
}

public class PlayerController : UnitController
{
    public int cakeRushLevel { get; set; }
    public int cokeShotLevel { get; set; }
    private LayerMask groundLayer;
    private LayerMask unitLayer;
    
    [SerializeField] private SkillStat[] cakeRush;
    [SerializeField] private SkillStat[] lightnig;
    [SerializeField] private GameObject cokeShotObject;
    protected override void Awake()
    {
        DataLoad("Player"); 
        cakeRushLevel = 0;
        cokeShotLevel = 0;
        base.Init();
        base.Awake();
    }

}
