using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFlamethrower : MonoBehaviour {

    public GameObject castPoint;
    public GameObject flamethrower;
    GameObject go;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.Mouse1))
        {
            go = (GameObject)Instantiate(flamethrower, (Vector2)castPoint.transform.position, Quaternion.identity);
            

        }
        go.transform.position = (Vector2)castPoint.transform.position;
        go.transform.rotation = castPoint.transform.rotation;
        Destroy(go, 3f);
    }
}
