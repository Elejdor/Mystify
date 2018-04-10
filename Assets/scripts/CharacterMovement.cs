using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovementTest : MonoBehaviour
{
    [SerializeField]       
    GameObject player;

    public float characterVelocity { get; private set; }
    public float jumpForce { get; private set; }
    public bool isGrounded;
    
    

	void Start ()
    {
        characterVelocity = 5f;
        jumpForce = 250f;
        isGrounded = true;
	}

    void Update()
    {
        if(Input.GetKey(KeyCode.A))     
            walk(-1f);
        if(Input.GetKey(KeyCode.D))
            walk(1f);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            jump();

    }


    public void jump()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce * Time.deltaTime);
        //player.transform.Translate(Vector2.up * jumpForce * Time.deltaTime);
        isGrounded = false;
    }

    public void walk(float _horizontal)
    {   
        player.transform.Translate(Vector2.right * characterVelocity * _horizontal * Time.deltaTime);    
        //changing direction flips player
    }

    public void aim()
    {
        //TO DO
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;

    }
}
