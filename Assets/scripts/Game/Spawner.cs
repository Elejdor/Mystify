using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
        GameObject _golire;
    [SerializeField]
        GameObject _breeze;
    [SerializeField]
        GameObject _treead;
    [SerializeField]
        Transform spawnBreeze;
    [SerializeField]
        Transform spawnGolire;
    [SerializeField]
        Transform spawnTreead;
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
            for(int i = 0; i < Random.Range(1, 5); i++)
            {
                Instantiate(_breeze, spawnBreeze.position, Quaternion.identity);
                randDistance = Random.Range(10, 80);
                spawnBreeze.position = new Vector2(spawnBreeze.position.x + randDistance, spawnBreeze.position.y);              
            }
        }
        if(_player.position.x + 50 >= spawnGolire.position.x)
        {
            for(int i = 0; i < Random.Range(1, 2); i++)
            {
                Instantiate(_golire, spawnGolire.position, Quaternion.identity);
                randDistance = Random.Range(40, 80);
                spawnGolire.position = new Vector2(spawnGolire.position.x + randDistance, spawnGolire.position.y);
            }
        }
        if(_player.position.x + 50 >= spawnTreead.position.x)
        {
            for(int i = 0; i < Random.Range(1, 2); i++)
            {
                Instantiate(_treead, spawnTreead.position, Quaternion.identity);
                randDistance = Random.Range(40, 80);
                spawnTreead.position = new Vector2(spawnTreead.position.x + randDistance, spawnTreead.position.y);     
            }
        }
    }
}