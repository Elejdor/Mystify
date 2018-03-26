using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWind : MonoBehaviour
{

    public GameObject wind;
    public int velocity = 10;
    public Vector2 offset = new Vector2(1.5f, 0f);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = (GameObject)Instantiate(wind, (Vector2)transform.position + offset, Quaternion.identity);

            Vector2 middle = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            Vector2 w = new Vector2(mousePos.x - middle.x, mousePos.y - middle.y);
            w.Normalize();
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(w.x * velocity, w.y * velocity);
            Destroy(go, 3f);

        }
    }
}
