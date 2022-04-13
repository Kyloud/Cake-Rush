using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public Transform _target;

    private void Start()
    {
        _target = null;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Y))
        {
            transform.position = new Vector3(_target.position.x, transform.position.y, _target.position.z);
        }
    }

    private void LateUpdate()
    {

        // 카메라 이동
        if(Input.mousePosition.x == 0)
        {

        }

        if(Input.mousePosition.z == 0)
        {

        }
    }
}
