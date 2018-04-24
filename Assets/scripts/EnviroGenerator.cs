using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour {

    public List<GameObject> down;
    public GameObject InstDown;
    int y = 0;
    bool flag = true;
    GameObject go;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ((transform.position.x % 5 == 0) && flag)
        {
            if (down[y].GetComponent<SpriteRenderer>().flipX)
            {
                down[y].GetComponent<SpriteRenderer>().flipX = true;
            }
            else down[y].GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(down[y], InstDown.transform.position, Quaternion.identity);
            y++;
            flag = false;
        }
        if (transform.position.x % 5 != 0) flag = true;
        if (y == 4) y = 0;
	}
}
