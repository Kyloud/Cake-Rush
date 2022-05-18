using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//싱글톤 제작시 상속시킬 모노 싱글톤
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour // where T 왜 있는지 궁금하면 지워봐요.
{
    // singletonation(싱글톤화), get type is public, but set type is private. because Concealability
    public static T instance { get; private set; }

    // input instance, type as Generic T
    private void Awake()
    {
        // 할당 (https://rucira-tte.tistory.com/115)
        // 변수 = 오브젝트 as 타입 (as 타입 안하면 FindObject로 타입이 반환된기에 캐스팅 해주는 것이다.)
        instance = FindObjectOfType(typeof(T)) as T;
    }
}
