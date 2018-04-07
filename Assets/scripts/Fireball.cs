using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float _velocity = 10f;
    
	void Start ()
    {
        Vector2 middle = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 pos = new Vector2(mousePos.x - middle.x, mousePos.y - middle.y);          
        pos.Normalize();
        GetComponent<Rigidbody2D>().velocity = new Vector2(pos.x * _velocity, pos.y * _velocity);
    }
}
