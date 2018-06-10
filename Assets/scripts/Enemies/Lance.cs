using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour {

    PlayerStats _player;
    Anger _anger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player = collision.gameObject.GetComponent<PlayerStats>();
        _anger = collision.gameObject.GetComponent<Anger>();

        if (collision.gameObject.layer == 9)
        {
            _player.Damage(50);
            _player._canRegen = false;
            _anger.Damage(50);
            _anger._canRegen = false;
        }
        
}


}
