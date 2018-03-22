using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : MonoBehaviour {

    public GameObject fireball;
    public Vector2 velocity = new Vector2(5.0f, 0f);
    public Vector2 offset = new Vector2(1.5f, 0f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject go = (GameObject)Instantiate(fireball, (Vector2)transform.position + offset, Quaternion.identity);
            //Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 castPointPosition = new Vector2(0, 0);

            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);
            Destroy(go, 3f);

        }
	}
}
