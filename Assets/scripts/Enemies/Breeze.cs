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
    [SerializeField]
    Rigidbody2D _breezePos;

    private int _hp;
    private float _speed;
    Vector2 _dir;
                                     
	void Start ()
    {                                        
        _speed = 5f;
        _breezePos = GetComponent<Rigidbody2D>();
	}
	                                    
	void Update ()
    {
        fly(); 
	}

    public void fly()
    {                                              
        _dir = _player.position - _breeze.transform.position; 
        _breezePos.AddForce(_dir * _speed, ForceMode2D.Force);
        if(_breeze.transform.position.y < 5f)
        {
            _breezePos.AddForce(Vector2.up * (1 / (_breeze.transform.position.y - 5)), ForceMode2D.Force);
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
