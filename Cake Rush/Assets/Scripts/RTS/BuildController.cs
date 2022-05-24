using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a Build Component class that is spwanable. 
public class BuildController : EntityBase
{
    public GameObject buildEffect;
    public bool isSpawned;
    private int[] returnCost;

    protected override void Awake()
    {
        buildEffect = transform.Find("BuildAnim").gameObject;
        base.Awake();
        curHp = 0f;
        StartCoroutine(Build());
    }
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && isSelected)
        {
            BuildCancel();
        }
        base.Update();
    }
    
    protected IEnumerator Build()
    {   
        buildEffect.SetActive(true);
        Debug.Log("Start Coroutine Build()");
        while (curHp < maxHp )
        {
            curHp += Time.deltaTime * spawnTime;
            yield return null;
        }
        curHp = maxHp;
        Debug.Log("Build() Completed");
        isActive = true;
        buildEffect.SetActive(false);
    }

    protected void BuildCancel()
    {
        // summon effect 
        // give player: returnCost / 2
        for(int i = 0; i < 2; i++)
        {
            Debug.Log($"{GameManager.instance.cost[i]} -> {GameManager.instance.cost[i] + returnCost[i]}");
            GameManager.instance.cost[i] += returnCost[i];
        }
        Debug.Log("Build Cancel()");
        Destroy(gameObject);
    }

    public void SelectBuilding(BuildController newBuild)
	{
        
	}

	public void DeselectBuilding(BuildController newBuild)
	{
        
	}
}