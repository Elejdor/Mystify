using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;
    PlayerStats _player;

                                   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();
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

        if(collision.gameObject.layer == 9)
        {
            _player.Damage(50);
            _player._canRegen = false;                     
        }
        Destroy(this.gameObject);
    }

}
