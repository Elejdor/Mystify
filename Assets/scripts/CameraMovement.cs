using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    GameObject Player;

    [SerializeField]
    float velocity = 5f;

    [SerializeField]
    float shakeAmount;

    [SerializeField]
    float length;
    Vector3 currVel;
    Vector3 newPos;
    Vector3 offset;
    Vector3 initPos;
    // Use this for initialization
    void Start () {

        offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        currVel = Player.GetComponent<Rigidbody2D>().velocity;
        if (Input.GetKey(KeyCode.A)) moveLeft();
        if (Input.GetKey(KeyCode.D)) moveRight();
        if (Input.GetKey(KeyCode.W)) jump();
        if (Input.GetKey(KeyCode.Q)) transform.position = Player.transform.position + offset;
        if (Input.GetKey(KeyCode.P))
        {
            Shake();
        }
      /*  if ((((transform.position.y + 2) - Player.transform.position.y) < 0) || (((Player.transform.position.y + 2) - transform.position.y) < 0)) 
        {
            newPos = transform.position;
            newPos.y = Player.transform.position.y;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currVel, 1);
        }*/
        if ((((transform.position.x + 5) - Player.transform.position.x) < 0) || (((Player.transform.position.x + 5) - transform.position.x) < 0))
        {
            newPos = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currVel, 2f);
        }
    }

    

    void moveRight()
    {
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, Player.GetComponent<Rigidbody2D>().velocity.y);
    }
    void moveLeft()
    {
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, Player.GetComponent<Rigidbody2D>().velocity.y);
    }
    void jump()
    {
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.GetComponent<Rigidbody2D>().velocity.x, velocity);
    }


    public void Shake()
    {
        initPos = transform.position;
        InvokeRepeating("BeginShake", 0, 0.1f);
        Invoke("StopShake", length);
        transform.position = initPos;
    }
    void BeginShake()
    {
        transform.position = initPos;
        if (shakeAmount > 0)
        {
            Vector3 camPos = transform.position;
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
    }
}
