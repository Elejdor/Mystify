using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;
    Anger _anger;
    PlayerStats _player;
    [SerializeField]
    Shake _shaker;

    [SerializeField]
    ParticleSystem _fireParticle;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();
        _anger = collision.gameObject.GetComponent<Anger>();
        _player = collision.gameObject.GetComponent<PlayerStats>();
        _shaker = collision.gameObject.GetComponent<Shake>();

        
        if(collision.gameObject.layer == 13)
        {
            if(collision.gameObject.name == "Treead")
            {
                _tree.Damage(50);         
                _tree._burnTime = 4f;
                _tree.afterBurn();        
            }  
            if(collision.gameObject.name == "Golire")
            {
                Debug.Log("Burn again!");
                _golire.extinguished = false;
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
            Shake.canShake = true;
            //_anger._canRegen = false;             
        }
        Destroy(this.gameObject);

        _fireParticle.Play();
        _fireParticle.transform.parent = null;
        Destroy(_fireParticle, 2.0f);
    }

}
