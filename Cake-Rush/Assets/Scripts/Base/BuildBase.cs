using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a Build Component class that is spwanable. 
public class BuildBase : EntityBase
{
    public GameObject buildEffect;
    public bool isSpawned;
        
    private int[] returnCost;
    
    [SerializeField] Material blueprintMat;
    [SerializeField] Material originMat;
    Renderer render;
    protected override void Awake()
    {
        render = gameObject.GetComponentInChildren<Renderer>();
        originMat = render.material;

        base.Awake();
        if(isSpawned)
        {
            render.material = blueprintMat;
            curHp = 0f;
            buildEffect = transform.Find("BuildAnim").gameObject;
           //StartCoroutine(Build());
        }
    }
    
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && isSelected)
        {
            BuildCancel();
        }
        base.Update();
    }
    
    public IEnumerator Build()
    {   
        buildEffect.SetActive(true);
        gameObject.layer = LayerMask.NameToLayer("Selectable");
        //gameObject.tag = "Build";
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
        render.material = originMat;
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

    public void SelectBuilding(BuildBase newBuild)
	{
        
	}

	public void DeselectBuilding(BuildBase newBuild)
	{
        
	}
}