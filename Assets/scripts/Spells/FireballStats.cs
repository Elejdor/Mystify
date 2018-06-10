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
    ParticleSystem _fireParticle;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();
        _anger = collision.gameObject.GetComponent<Anger>();
        _player = collision.gameObject.GetComponent<PlayerStats>();

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
<<<<<<< HEAD
=======
            _anger._canRegen = false;
>>>>>>> 9dcca073c7a45c1729eac6e5f2f0164474e1798e
        }
        Destroy(this.gameObject);

        _fireParticle.Play();
        _fireParticle.transform.parent = null;
        Destroy(_fireParticle, 3.0f);
        Physics2D.IgnoreCollision(this.transform.GetComponent<Collider2D>(), _player.transform.GetComponent<Collider2D>());
    }

}
