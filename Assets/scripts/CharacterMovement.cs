using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]       
    GameObject player;

    public float _characterVelocity { get; private set; }
    public float _jumpForce { get; private set; }
    public bool _isGrounded {get; private set; }
            
    
    void Start ()
    {
        _characterVelocity = 5f;
        _jumpForce = 350f;
        _isGrounded = true;
	}

    public void jump()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _jumpForce * Time.deltaTime); 
        _isGrounded = false;
    }

    public void walk(InputManager input)
    {                                            
        player.transform.Translate(Vector2.right * _characterVelocity * input._horizontal * Time.deltaTime);       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            _isGrounded = true;      
    }
}
