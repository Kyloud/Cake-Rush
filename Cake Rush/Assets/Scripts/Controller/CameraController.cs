using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    RTSController rtsController;
    Vector3 originPos;
    Transform playerTransform;
    float speed;
    bool isLock;

    void Awake()
    {
        originPos = new Vector3(0.0f, 17.0f, -15.0f);
        rtsController = GameObject.FindWithTag("GameController").GetComponent<RTSController>();
        isLock = false;
        speed = 5f;
        // playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        SetPosToSelectedEntity();
        SetPosToPlayer();

        PosLockToUnitPos();
        
    }
    
    void SetPosToPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z - 11f);
        }
    }

    void SetPosToSelectedEntity()
    {
        if(Input.GetKey(KeyCode.T) && rtsController.selectedUnitList.Count > 0)
        {
            transform.position = new Vector3
            (
                rtsController.selectedUnitList[0].transform.position.x,
                transform.position.y,
                rtsController.selectedUnitList[0].transform.position.z - 11f
            );
        }
    }

    void PosLockToUnitPos()
    {
        if(isLock && rtsController.selectedUnitList.Count > 0)
        {
            transform.position = new Vector3
            (
                rtsController.selectedUnitList[0].transform.position.x,
                transform.position.y,
                rtsController.selectedUnitList[0].transform.position.z - 11f
            );
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if(isLock)
            {
                isLock = false;
                return;
            }
            else
            {
                isLock = true;
                return;
            }
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow) || (Input.mousePosition.y >= Screen.height - 100 ))
        { 
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || (Input.mousePosition.y <= 100 ))
        {  
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) ||  (Input.mousePosition.x <= 100))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }   
        else if (Input.GetKey(KeyCode.RightArrow) || (Input.mousePosition.x >= Screen.width - 100))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
