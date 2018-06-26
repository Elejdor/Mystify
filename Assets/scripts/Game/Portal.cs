using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{                             

    public void Start()
    {                            

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {                                
        UIOptions.ChangeScene("Anger"); 
    }    
}
