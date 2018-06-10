using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;
    [SerializeField]
    ParticleSystem _windParticle;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {          
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();

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

        if(collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject); 
        }

        Destroy(this.gameObject);

        _windParticle.Play();
        _windParticle.transform.parent = null;       
        Destroy(_windParticle, 3.0f);

    }
}
