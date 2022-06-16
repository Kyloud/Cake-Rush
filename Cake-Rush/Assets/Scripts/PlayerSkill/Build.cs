using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] public GameObject cookieHouseObj;
    [SerializeField] public GameObject costBuildObj;
    public string cookieHouseName;
    public string costBuildName;

    [SerializeField] public bool isBuildMode;

    void Awake()
    {
        isBuildMode = false;
        if(cookieHouseObj == null) cookieHouseObj = Resources.Load<GameObject>("Prefabs/CookieHouse");
        if(costBuildObj == null) costBuildObj = Resources.Load<GameObject>("Prefabs/CostBuild");
        
        if(cookieHouseObj != null) cookieHouseName = cookieHouseObj.name;
        if(costBuildObj != null) costBuildName = costBuildObj.name;       
    }
}