using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임의 승패 관리, 인벤트 생성 등 인게임 진행 담당
public class GameProgress : MonoSingleton<GameProgress>
{
    public bool isGameOver;

    public LayerMask groundLayer;
    public LayerMask selectableLayer;

    private void Awake()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
        selectableLayer = 1 << LayerMask.NameToLayer("Selectable");
    }

    public void CountDown()
    {

    }

    public void FinalGame()
    {

    }

    public void GameOver()
    {
        
    }
}
