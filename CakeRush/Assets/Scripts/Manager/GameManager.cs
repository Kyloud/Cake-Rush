using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public RTSContoller rtsController;
    public int[] cost;
    public bool isSpawnable;
}
