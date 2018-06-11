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
    static public bool canShake = false;

    Vector3 playerPos;
    Vector3 rand;

    void Update()
    {
        if(canShake)
        {
            ShakeBegin(0.5f, 0.5f);
            StartCoroutine(ShakeTime(0.2f) );
        }
    }

    public IEnumerator ShakeTime(float time)
    {
        yield return new WaitForSeconds(time);
        canShake = false;
    }

    public void ShakeBegin(float shakeDuration, float amount)
    {                  
        if (shakeDuration > 0)
        {
            playerPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            rand = new Vector3(Random.value, Random.value, -10);
            transform.position = playerPos + rand * amount * shakeDuration;
            shakeDuration -= Time.deltaTime;
        }
        else if (shakeDuration <= 0 && shakeDuration >= -5)
        {
            shakeDuration = -10;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2, -10);
        }             
    }
}
