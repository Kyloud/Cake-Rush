using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRush : MonoBehaviour
{
    [SerializeField] private SkillStat[] cakeRush;
    public int cakeRushLevel { get; set; }

    private void Awake()
    {
        
    }

    public void UnitCakeRush(int skillLevel)
    {
        Debug.Log($"Cake Rush! | Level {skillLevel}");
    }
}
