﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject _golire;
    [SerializeField]
    GameObject _breeze;
    [SerializeField]
    Transform spawnBreeze;
    [SerializeField]
    Transform spawnGolire;
    [SerializeField]
    Transform _player;

    float randDistance;

    void Start()
    {

    }


    void Update()
    {
        if(_player.position.x + 50 >= spawnBreeze.position.x)
        {
            Instantiate(_breeze, spawnBreeze.position, Quaternion.identity);
            randDistance = Random.Range(10, 80);
            spawnBreeze.position = new Vector2(spawnBreeze.position.x + randDistance, spawnBreeze.position.y);
        }
        if(_player.position.x + 50 >= spawnGolire.position.x)
        {
            Instantiate(_golire, spawnGolire.position, Quaternion.identity);
            randDistance = Random.Range(40, 80);
            spawnGolire.position = new Vector2(spawnGolire.position.x + randDistance, spawnGolire.position.y);
        }

    }
}