using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터가 생성하는 건물의 최상위 클래스
public class BuildController : EntityBase
{
    private int[] returnCost;
    
    protected IEnumerator Build()
    {
        yield return null;
    }

    protected void BuildCancel()
    {

    }

    private void DeselectBuild(BuildController newBuild)
    {

    }

    private void SelectBuild(BuildController newBuild)
    {

    }
}