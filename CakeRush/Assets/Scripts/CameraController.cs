using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    RTSController rtsController;
    Vector3 originPos;

    void Start()
    {
        // set originPos
        if(tag == "Team1")
        {
            originPos = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (tag == "Team2")
        {
            originPos = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow) || (Input.mousePosition.y >= Screen.height - 50f))
        {

        }
        else if (Input.GetKey(KeyCode.DownArrow) || (false))
        {

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || (false))
        {

        }
        else if (Input.GetKey(KeyCode.RightArrow) || (false))
        {

        }
    }
}