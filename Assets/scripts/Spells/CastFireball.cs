using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : MonoBehaviour
{

    [SerializeField]
    GameObject castPoint;

    [SerializeField]
    GameObject fireball;

    float velocity = 24;     

    public void Cast( Vector2 dir )
    {
        GameObject go = (GameObject)Instantiate(fireball, castPoint.transform.position, Quaternion.identity);
        go.transform.right = dir.normalized;
        go.GetComponent<Rigidbody2D>().velocity = dir * velocity;
        Destroy( go, 3f );
    }
}
