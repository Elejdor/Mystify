using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {

    [SerializeField]
    Transform _target;

    Vector3 _offset;

    void Start()
    {
        _offset = _target.position - transform.position;
    }

    void FixedUpdate()
    {
        transform.position = _target.position - _offset;
    }

}
