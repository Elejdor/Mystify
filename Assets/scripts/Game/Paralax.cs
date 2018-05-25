using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [Serializable]
    public class ParalaxLayer
    {
        public Transform _transform;
        public float _speed;
        public Vector3 _initialPos;
    }

    [SerializeField]
    ParalaxLayer[] _layers;

    [SerializeField]
    Transform _camera;

    float _initialOffset;

    void Start()
    {
        _initialOffset = _camera.transform.position.x;

        foreach (ParalaxLayer layer in _layers)
        {
            layer._initialPos = layer._transform.position;
        }
    }

    void Update()
    {
        float diff = _camera.transform.position.x - _initialOffset;
        foreach ( ParalaxLayer layer in _layers )
        {
            layer._transform.position = Vector3.right * diff * layer._speed + layer._initialPos;
        }
    }


}
