using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameInfo : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text maxPerCurUnitText; 
    [SerializeField] Text[] costsText= new Text[3];
    
    float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

}
