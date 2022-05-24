using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//싱글톤 제작시 상속시킬 모노 싱글톤
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    public static T instance { get; private set; }

    private void Awake()
    {
        instance = FindObjectOfType(typeof(T)) as T;
    }
}
