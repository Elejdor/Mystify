using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {

    [SerializeField]
    Transform _target;

    public Vector3 pos;

    Vector3 _offset;

    Vector3 _peekScale = new Vector3(1.0f, 0.6f);

    void FixedUpdate()
    {
        transform.position = _target.position + _offset * 0.2f;
        pos = transform.position;
    }

    public void SetAiming(Vector3 dir)
    {
        _offset = Vector3.Scale( dir, _peekScale );
    }
}
