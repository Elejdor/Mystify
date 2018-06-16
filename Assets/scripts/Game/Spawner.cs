using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

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

    int randBreeze;
    float randDistance;
    float spawnerY;

	void Start () {
        spawnerY = spawnBreeze.position.y;

    }
	
	
	void Update () {
		if(_player.position.x + 50 >= spawnBreeze.position.x)
        {
            randBreeze = Random.Range(1, 4);
            for (int i = 0; i <= randBreeze; i++)
            {
                Instantiate(_breeze, spawnBreeze.position, Quaternion.identity);
                spawnBreeze.position = new Vector2(spawnBreeze.position.x, spawnBreeze.position.y + Random.Range(-3, 3));
            }
            spawnBreeze.position = new Vector2(spawnBreeze.position.x, spawnerY);
            randDistance = Random.Range(50, 100);
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
