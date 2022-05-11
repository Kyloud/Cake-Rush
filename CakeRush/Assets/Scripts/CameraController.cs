using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    // Cameram Main Target
    [SerializeField] public Transform target;
    // Camera Movement Speed
    [SerializeField] float speed = 10;
    [SerializeField] private Vector3 originPosition;
    private float mousePosforMove = 40f;
    
    [SerializeField] private List<Transform> units = new List<Transform>();

    [SerializeField] private Transform unit;
    
    [SerializeField] private Vector3 destPos;
    
    private void Start()
    {
        originPosition = transform.position;
        target = null;
    }
    
    void Update()
    {
                
    }

    private void LateUpdate()
    {
        CameraMovement();
        if (Input.GetMouseButton(0))
        {
            ShotRay();
        }
    }
    
    void CameraMovement()
    {
        if(Input.mousePosition.x >= Screen.width - mousePosforMove)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }

        if(Input.mousePosition.y >= Screen.height - mousePosforMove)
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }

        if(Input.mousePosition.x <= mousePosforMove)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
        
        if (Input.mousePosition.y <= mousePosforMove)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            if(target == null)
            {
                transform.position = originPosition;
            }
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        }
        
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }
        }
    }
    
    void ShotRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
            {
                Debug.Log("Hit Unit");
                target = hit.transform;
                
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Debug.Log("Hit Ground");
                //units.Add(hit.transform);
                unit = hit.transform;
                destPos = hit.collider.transform.position;
            }
        }
        Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
    }


            //Change Cursor

            //if (_cursorType != CursorType.Attack)
            //{
            //    Cursor.SetCursor(_attackIcon, new Vector2(_attackIcon.width / 5, 0), CursorMode.Auto);
            //    _cursorType = CursorType.Attack;
            //}

            //else
            //{
            //    if (_cursorType != CursorType.Hand)
            //    {
            //        Cursor.SetCursor(_handIcon, new Vector2(_handIcon.width / 3, 0), CursorMode.Auto);
            //        _cursorType = CursorType.Hand;
            //    }
            //}
}

