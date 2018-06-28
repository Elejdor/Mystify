using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;
    Anger _anger;
    [SerializeField]
    PlayerStats _player;
    Breeze _breeze;
    [SerializeField]
    Shake _shaker;

    [SerializeField]
    ParticleSystem _fireParticle;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();
        _breeze = collision.gameObject.GetComponent<Breeze>();
        _anger = collision.gameObject.GetComponent<Anger>();
        _player = collision.gameObject.GetComponent<PlayerStats>();
        _shaker = collision.gameObject.GetComponent<Shake>();

        
        if(collision.gameObject.layer == 13 || collision.gameObject.layer == 14)
        {
            if(collision.gameObject.name == "Treead" || collision.gameObject.name == "Treead(Clone)")
            {
                _tree.Damage(50);         
                _tree._burnTime = 4f;
                _tree.afterBurn();        
            }  
            if(collision.gameObject.name == "Golire" || collision.gameObject.name == "Golire(Clone)")
            {
                Debug.Log("Burn again!");
                _golire.extinguished = false;
            }
            if (collision.gameObject.name == "Breeze" || collision.gameObject.name == "Breeze(Clone)")
            {
                _breeze.Damage(50);
            }

        }
        if (collision.gameObject.layer == 14)
        {
            if (collision.gameObject.name == "Anger")
            {
                _anger.Damage(50);
                _anger._canRegen = false;
            }
            
        }

        if (collision.gameObject.layer == 9)
        {
            _player.Damage(50);                          
            _player._canRegen = false;
            _anger.Damage(1000);
            _anger._canRegen = false; 
            Debug.Log("I hit him!");
            Shake.canShake = true;
        }
        Destroy(this.gameObject);

        _fireParticle.Play();
        _fireParticle.transform.parent = null;
        Destroy(_fireParticle, 2.0f);
    }

}
