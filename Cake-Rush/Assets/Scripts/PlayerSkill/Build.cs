using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] public GameObject cookieHouseObj;
    [SerializeField] public GameObject sugarMinerObj;
    [SerializeField] public GameObject chocolateMinerObj;

    public string cookieHouseName;
    public string sugerMinerName;
    public string chocolateMinerName;
    [SerializeField] public bool isBuildMode;

    void Awake()
    {
        isBuildMode = false;
        if(cookieHouseObj == null) cookieHouseObj = Resources.Load<GameObject>("Prefabs/CookieHouse");
        if(sugarMinerObj == null) sugarMinerObj = Resources.Load<GameObject>("Prefabs/SugarMiner");
        if(chocolateMinerObj == null) chocolateMinerObj = Resources.Load<GameObject>("Prefabs/ChocolateMiner");

        if(cookieHouseObj != null) cookieHouseName = cookieHouseObj.name;
        if(sugarMinerObj != null) sugerMinerName = sugarMinerObj.name;
        if(chocolateMinerObj != null) chocolateMinerName = chocolateMinerObj.name;
    }
}