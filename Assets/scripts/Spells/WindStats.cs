﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;
<<<<<<< HEAD
    [SerializeField]
    ParticleSystem _windParticle;
    
=======
    Anger _anger;
>>>>>>> 9dcca073c7a45c1729eac6e5f2f0164474e1798e


    private void OnCollisionEnter2D(Collision2D collision)
    {          
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();
        _anger = collision.gameObject.GetComponent<Anger>();

        if(collision.gameObject.layer == 13)
        {   
            if(collision.gameObject.name == "Treead")
            {
                Debug.Log("RASENGAN!");
                _tree._burnTime = 0f;       
            }  
            if(collision.gameObject.name == "Golire")
            {
                Debug.Log("You'r not burning anymore!");
                _golire.extinguished = true;                 
            }
        }
        if (collision.gameObject.layer == 14)
        {
            if (collision.gameObject.name == "Anger")
            {
                _anger.Damage(30);
                _anger._canRegen = false;
            }
        }

        if (collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject); 
        }

        Destroy(this.gameObject);

        _windParticle.Play();
        _windParticle.transform.parent = null;       
        Destroy(_windParticle, 3.0f);

    }
}