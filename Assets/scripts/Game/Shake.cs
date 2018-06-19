using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
    [SerializeField]
        float shakeDuration;
    [SerializeField]
        float amount;
    [SerializeField]
    Transform cam;

    float duration = -10;
    static public bool canShake = false;

    Vector3 shakePos;
    Vector3 rand;

    void Update()
    {
        ShakeBegin(0.3f, 0.3f);
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
            shakePos = new Vector3(cam.position.x, cam.position.y, -10);
            rand = new Vector3(Random.value, Random.value, -10);
            transform.position = shakePos + rand * amount * shakeDuration;
            shakeDuration -= Time.deltaTime;
        }
        else if (shakeDuration <= 0 && shakeDuration >= -5)
        {
            shakeDuration = -10;
            transform.position = new Vector3(cam.position.x, cam.position.y, -10);
        }             
    }
}
