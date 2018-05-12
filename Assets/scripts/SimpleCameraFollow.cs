using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {

    [SerializeField]
    Transform _target;

    Vector3 _offset;
    float _speed = 0.1f;

    void Start()
    {
        _offset = _target.position - transform.position;
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp( transform.position, _target.position - _offset, _speed );
    }
}
