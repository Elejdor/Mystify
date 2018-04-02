﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWind : MonoBehaviour
{
    [SerializeField]
    GameObject castPoint;

    [SerializeField]
    GameObject wind;

    float velocity = 10;

    public void Cast( Vector2 dir )
    {
        GameObject go = (GameObject)Instantiate(wind, castPoint.transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = dir * velocity;
        Destroy( go, 3f );
    }
}
