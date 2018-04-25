using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour {

    public List<GameObject> down;
    public GameObject InstDown;
    int y = 0;
    bool flag = true;
    float rand;
    GameObject go;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((InstDown.transform.position.x <= (transform.position.x + 12)) && flag==true)
        {
            Instantiate(down[y], InstDown.transform.position, Quaternion.identity);
            rand = Random.Range(5f, 20f);
            InstDown.transform.position = new Vector3(InstDown.transform.position.x + rand, InstDown.transform.position.y, InstDown.transform.position.z);
            y++;
            flag = false;
        }
        flag = true;
        if (y == 4) y = 0;
	}
}
