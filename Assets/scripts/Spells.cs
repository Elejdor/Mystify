using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject castPoint;
    public GameObject fireball;  
    public GameObject wind;      
    public GameObject flamethrower;
    public GameObject go;

    public int velocity = 10;

    Spells()
    {
        

    }



    public void Fireball()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(fireball, (Vector2)castPoint.transform.position, Quaternion.identity);

            
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 middle = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 pos = new Vector2(mousePos.x - middle.x, mousePos.y - middle.y);
            pos.Normalize();
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(pos.x * velocity, pos.y * velocity);
            Destroy(go, 3f);

        }
    }

    public void Wind()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = (GameObject)Instantiate(wind, (Vector2)castPoint.transform.position, Quaternion.identity);

            Vector2 middle = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            Vector2 pos = new Vector2(mousePos.x - middle.x, mousePos.y - middle.y);
            pos.Normalize();
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(pos.x * velocity, pos.y * velocity);
            Destroy(go, 3f);

        }
    }

    public void FlameThrower()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.Mouse1))
        {
            go = (GameObject)Instantiate(flamethrower, (Vector2)castPoint.transform.position, Quaternion.identity);


        }
        go.transform.position = (Vector2)castPoint.transform.position;
        go.transform.rotation = castPoint.transform.rotation;
        Destroy(go, 3f);
    }   
};
