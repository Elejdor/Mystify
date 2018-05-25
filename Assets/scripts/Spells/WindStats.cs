using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStats : MonoBehaviour
{
    Treead _tree;    


    private void OnCollisionEnter2D(Collision2D collision)
    {          
        _tree = collision.gameObject.GetComponent<Treead>();
        if(collision.gameObject.layer == 13)
        {   
            if(_tree.type == EnemyTypes.Treead)
            {
                Debug.Log("RASENGAN!");
                _tree._burnTime = 0f;
                Destroy(this.gameObject);
            }
            if(_tree.type == EnemyTypes.Breeze)
            {

            }
            if(_tree.type == EnemyTypes.Golire)
            {

            }
        }               

        if(collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.layer == 8)
        {                                             
            Destroy(this.gameObject);
        }
    }

}
