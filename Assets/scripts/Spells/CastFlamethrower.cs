using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFlamethrower : MonoBehaviour
{

    [SerializeField]
    GameObject castPoint;

    [SerializeField]
    FlameEffect flame;

    public void Cast()
    {
        flame.Play();
        FollowHand();
    }

    public void Stop()
    {
        flame.Stop();
    }

    void FollowHand()
    {
        flame.transform.position = (Vector2)castPoint.transform.position;
        flame.transform.rotation = castPoint.transform.rotation;
    }
}
