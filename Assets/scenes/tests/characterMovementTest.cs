using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public float characterVelocity
    {
        get; private set;
    }
    public float jumpForce
    {
        get; private set;
    }
    public bool isGrounded;



    void Start()
    {
        characterVelocity = 32f;
        jumpForce = 32f;
        isGrounded = true;
    }


    public void jump()
    {
        player.transform.Translate(Vector2.up * jumpForce * Time.deltaTime);
    }

    public void walk(InputManager input)
    {
        player.transform.Translate(Vector2.right * characterVelocity * input._horizontal * Time.deltaTime);
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
