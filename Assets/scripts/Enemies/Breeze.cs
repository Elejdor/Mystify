using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeze : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
    GameObject _breeze;
    [SerializeField]
    Transform _player;
    [SerializeField]
    SpriteRenderer _renderer;
    [SerializeField]
    Rigidbody2D _breezePos;

    PlayerStats player;

    private float _hp;
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
        Destroy(_breeze);
    }


    public void Damage(float damage)
    {
        Debug.Log("HP: " + _hp);
        _hp -= damage;
        if(_hp <= 0)
            death();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerStats>();

        if (collision.gameObject.layer == 9)
        {
            player.Damage(50);
            player._canRegen = false;
            Shake.canShake = true;
            death();
        }
    }
}
