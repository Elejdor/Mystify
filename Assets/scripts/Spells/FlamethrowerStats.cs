using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerStats : MonoBehaviour
{
    Treead _tree;
    Golire _golire;

    private void OnCollisionStay2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        _golire = collision.gameObject.GetComponent<Golire>();

        if(collision.gameObject.layer == 13)
        {
            if(collision.gameObject.name == "Treead")
            {
                _tree.Damage(1);
            }   
            if(collision.gameObject.name == "Golire")
            {
                Debug.Log("Burn again!");
                _golire.extinguished = false;
            }

        }


        if(collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

    }

}
