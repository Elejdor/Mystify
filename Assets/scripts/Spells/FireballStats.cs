using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballStats : MonoBehaviour
{
    Treead _tree;

                                   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        if(collision.gameObject.layer == 13)
        {
            if(_tree.type == EnemyTypes.Treead)
            {
                _tree.Damage(50);
                _tree._burnTime = 4f;
                _tree.afterBurn();

                Destroy(this.gameObject);
            }
            if(_tree.type == EnemyTypes.Breeze)
            {

            }
            if(_tree.type == EnemyTypes.Golire)
            {

            }

        }                

        if(collision.gameObject.layer == 8)
        {                       
            Destroy(this.gameObject);
        }
    }

}
