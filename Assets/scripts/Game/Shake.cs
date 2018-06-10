using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
    [SerializeField]
        float shakeDuration;
    [SerializeField]
        float amount;
    [SerializeField]
    GameObject player;

    float duration = -10;

    Vector3 playerPos;
    Vector3 rand;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            duration = shakeDuration;
        }
        if (duration > 0)
        {
            playerPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            rand = new Vector3(Random.value, Random.value, -10);
            transform.position = playerPos + rand * amount * duration;
            duration -= Time.deltaTime;
        }
        else if (duration <= 0 && duration >= -5)
        {
            duration = -10;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2, -10);
        }
    }
}
