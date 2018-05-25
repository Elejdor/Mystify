using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerStats : MonoBehaviour
{
    Treead _tree;

    private void OnCollisionStay2D(Collision2D collision)
    {
        _tree = collision.gameObject.GetComponent<Treead>();
        if(collision.gameObject.layer == 13)
        {
            if(_tree.type == EnemyTypes.Treead)
            {
                _tree.Damage(1);
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
