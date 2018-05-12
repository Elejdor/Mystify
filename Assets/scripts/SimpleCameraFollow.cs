using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {

    [SerializeField]
    Transform _target;

    Vector3 _offset;

    void FixedUpdate()
    {
        transform.position = _target.position + _offset * 0.2f;
    }

    public void SetAiming(Vector3 dir)
    {
        _offset = dir;
    }
}
