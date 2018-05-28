using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeze : MonoBehaviour, IDamageable<int>
{
    [SerializeField]
    GameObject _breeze;
    [SerializeField]
    Transform _player;
    [SerializeField]
    SpriteRenderer _renderer;   

    private int _hp;
    private float _speed;
                                     
	void Start ()
    {                                        
        _speed = 5f;
	}
	                                    
	void Update ()
    {
        fly(); 
	}

    public void fly()
    {
        if(_player.position.x > (_breeze.transform.position.x + 0.3f))
        {
            _breeze.transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _renderer.flipX = true;
        }
        if(_player.position.x < (_breeze.transform.position.x - 0.3f))
        {
            _breeze.transform.Translate(Vector2.left * _speed * Time.deltaTime);
            _renderer.flipX = false;
        }
        if(_player.position.y > (_breeze.transform.position.y - 3))
        {
            _breeze.transform.Translate(Vector2.up * _speed * Time.deltaTime);     
        }
        if(_player.position.y < (_breeze.transform.position.y + 3))
        {
            _breeze.transform.Translate(Vector2.down * _speed * Time.deltaTime);  
        }
    }

    public void attack()
    {

    }

    public void death()
    {

    }


    public void Damage(int damage)
    {
        Debug.Log("HP: " + _hp);
        _hp -= damage;
        //if(_hp <= 0)
            //death();
    }
}
