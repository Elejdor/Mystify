using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour {

    [SerializeField]
    GameObject _treead;
    [SerializeField]
    GameObject _golire;
    [SerializeField]
    GameObject _breeze;
    [SerializeField]
    Transform _spawn;

    int waveCounter = 0;
    int randEnemie;
    int randAmount;
    float randTime;
    int maxEnemies = 2;
    int tempEnemies;
    int counter = 0;
    bool canSpawn = true;
    
	void Update () {
        if (canSpawn)
        {
            if (tempEnemies <= 0)
            {
                canSpawn = false;
                StartCoroutine("interWave");
                counter++;
                if (counter >= 5)
                {
                    maxEnemies++;
                    counter = 0;
                }

                tempEnemies = maxEnemies;
            }
            randEnemie = Random.Range(0, 3);
            randAmount = Random.Range(0, tempEnemies + 1);
            tempEnemies -= randAmount;
            switch (randEnemie)
            {
                case 0:
                    {
                        Spawn(_treead, randAmount);
                    }; break;
                case 1:
                    {
                        Spawn(_golire, randAmount);
                    }; break;
                case 2:
                    {
                        Spawn(_breeze, randAmount);
                    }; break;
            }

        }
	}

    void Spawn(GameObject enemy, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemy, _spawn.position, Quaternion.identity);
            StartCoroutine("cooldown");
        }
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator interWave()
    {
        randTime = Random.Range(5f, 10f);
        yield return new WaitForSeconds(randTime);
        canSpawn = true;
    }

}
