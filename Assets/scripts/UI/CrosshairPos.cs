using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPos : MonoBehaviour
{
    Vector3 _mousePos;
    [SerializeField]
    Transform _playerPos;

	// Use this for initialization
	void Start ()
    {
        _mousePos = Input.mousePosition;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {                
        _mousePos = Input.mousePosition;
        _mousePos.z = 10.0f;
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        this.gameObject.transform.position = _mousePos;
    }
}
