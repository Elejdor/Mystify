using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : MonoBehaviour {

    public GameObject castPoint;
    public GameObject fireball;
    public int velocity = 32;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject go = (GameObject)Instantiate(fireball, (Vector2)castPoint.transform.position, Quaternion.identity);

            Vector2 middle = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
            Vector2 pos = new Vector2(mousePos.x - middle.x, mousePos.y - middle.y);
            pos.Normalize();
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(pos.x* velocity, pos.y*velocity);
            Destroy(go, 3f);

        }
	}
}
