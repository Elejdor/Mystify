using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]       
    GameObject player;

    public float characterVelocity { get; private set; }
    public float jumpForce { get; private set; }
    public bool isGrounded {get; private set; }
            
    
    void Start ()
    {
        characterVelocity = 5f;
        jumpForce = 350f;
        isGrounded = true;
	}

    public void jump()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce * Time.deltaTime); 
        isGrounded = false;
    }

    public void walk(InputManager input)
    {                                            
        player.transform.Translate(Vector2.right * characterVelocity * input._horizontal * Time.deltaTime);       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;      
    }
}
