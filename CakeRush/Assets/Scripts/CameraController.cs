using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ī�޶� Ÿ��
    [SerializeField] public Transform _target;
    // ī�޶� �̵��ӵ�
    [SerializeField] float _speed;
    // ī�޶�
    Camera _cam;

    private void Start()
    {
        _target = null;
        _cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
              
    }

    private void LateUpdate()
    {
        // ���콺 ����
        if(Input.mousePosition.x >= Screen.width - 20f)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        }

        if(Input.mousePosition.y >= Screen.height - 20f)
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * _speed;
        }

        if(Input.mousePosition.x <= 20f)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * _speed;
        }
        trans
        if (Input.mousePosition.y <= 20f)
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * _speed;
        }

        // ���� ��Ŀ��
        if (Input.GetKey(KeyCode.Y))
        {
            transform.position = new Vector3(_target.position.x, transform.position.y, _target.position.z);
        }
        // ����Ű ����
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, 1) * Time.deltaTime * _speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -1) * Time.deltaTime * _speed;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * _speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * _speed;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            asd();
        }
    }


    void asd()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
            {
                Debug.Log("Hit");

                _target = hit.transform;
                //if (_cursorType != CursorType.Attack)
                //{
                //    Cursor.SetCursor(_attackIcon, new Vector2(_attackIcon.width / 5, 0), CursorMode.Auto);
                //    _cursorType = CursorType.Attack;
                //}
            }
            //else
            //{
            //    if (_cursorType != CursorType.Hand)
            //    {
            //        Cursor.SetCursor(_handIcon, new Vector2(_handIcon.width / 3, 0), CursorMode.Auto);
            //        _cursorType = CursorType.Hand;
            //    }
            //}
        }
    }
}

