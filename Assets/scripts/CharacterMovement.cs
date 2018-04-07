using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]       
    GameObject player;

    public float characterVelocity { get; private set; }
    public float jumpForce { get; private set; }
    
    

	void Start ()
    {
        characterVelocity = 32f;
        jumpForce = 32f;
	}

    public void jump()
    {
        player.transform.Translate(Vector2.up * jumpForce * Time.deltaTime);
        //Checking if standing on ground
        //if(yes) - we can jump
        //if(no) - we have to wait till he reaches ground
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
                  
}
