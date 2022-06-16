using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarMiner : BuildBase
{
    [SerializeField] private GameObject[] units = new GameObject[4];
    
    private float curTime = 0f;
    private int costPerSec = 10;

    protected override void Awake()
    {
        isSpawned = true;
        //DataLoad("CookieHouse"); 
        base.Awake();
    }

    void Start()
    {

    }

    protected override void Update()
    {
        base.Update();

        if(isSelected && isActive)
        {
            MineSugar();
        }
    }

    void MineSugar()
    {
        
    }
}
