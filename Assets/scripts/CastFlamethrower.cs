using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFlamethrower : MonoBehaviour {

    [SerializeField]
    GameObject castPoint;

    [SerializeField]
    GameObject flamethrower;

    GameObject flame;

    public void Cast()
    { 
        flame = (GameObject)Instantiate( flamethrower, (Vector2)castPoint.transform.position, Quaternion.identity );
        StartCoroutine( HandFollow() );
        Destroy( flame, 3f );   
    }

    IEnumerator HandFollow()
    {
        while ( flame )
        {
            flame.transform.position = (Vector2)castPoint.transform.position;
            flame.transform.rotation = castPoint.transform.rotation;
            yield return null;
        }
    }
}
