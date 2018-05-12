using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {

    [SerializeField]
    Transform _target;

    Vector2 _pos2;

    float _maxSpeed = 8.0f;
    float _threshold = 2.0f;
    float _speed = 0.0f;

	// Update is called once per frame
	void Update () {
        _pos2 = transform.position;
        Vector2 targetPos2 = _target.position;
        float dist = ( _pos2 - targetPos2 ).sqrMagnitude;
        
        if ( dist > _threshold )
        {
            _speed = (dist - _threshold ) * ( dist - _threshold );
            if ( _speed > _maxSpeed )
                _speed = _maxSpeed;
        }
        else
        {
            _speed = 0.0f;
        }

        Vector2 dir = targetPos2 - _pos2;
        dir.Normalize();
        transform.position += new Vector3( dir.x, dir.y, 0 ) * _speed * Time.deltaTime;
    }
}
