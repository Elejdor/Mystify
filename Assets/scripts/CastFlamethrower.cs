using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFlamethrower : MonoBehaviour {

    public GameObject flamethrower;
    public Vector2 offset = new Vector2(1.5f, 0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject go = (GameObject)Instantiate(flamethrower, (Vector2)transform.position + offset, Quaternion.identity);
            Destroy(go, 3f);

        }

    }
}
