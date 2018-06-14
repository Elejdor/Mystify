using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;
    Breeze _breeze;
    Anger _anger;

    private void OnCollisionStay2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();
        _anger = collision.gameObject.GetComponent<Anger>();
        _breeze = collision.gameObject.GetComponent<Breeze>();

        if (collision.gameObject.layer == 13)
        {
            if(collision.gameObject.name == "Treead")
            {
                _tree.Damage(10 * Time.deltaTime);
            }   
            if(collision.gameObject.name == "Golire")
            {
                Debug.Log("Burn again!");
                _golire.extinguished = false;
            }
            if (collision.gameObject.name == "Breeze")
            {
                _breeze.Damage(10 * Time.deltaTime);
            }

        }
        if (collision.gameObject.layer == 14)
        {
            if (collision.gameObject.name == "Anger")
            {
                _anger.Damage(10 * Time.deltaTime);
                _anger._canRegen = false;
            }
            

        }


        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

    }

}
