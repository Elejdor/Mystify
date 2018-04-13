using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Treead : MonoBehaviour
{
    [SerializeField]
    GameObject _tree;
    [SerializeField]
    Transform _player;
    [SerializeField]
    SpriteRenderer _renderer;

    public int _hpMax { get; private set; }
    public int _hp { get; private set; }
    public float _velocity { get; private set; }
    public float _attackRange{ get; private set; }   
    bool _attackReady;
    bool _isBurning;
    float _distance;


    void Start()
    {
        _hpMax = 250;
        _hp = _hpMax;
        _velocity = 2f;
        _attackRange = 3f;
        _attackReady = true;
        _isBurning = false;
    }

    private void Update()
    {
        _distance = Mathf.Abs(_player.position.x - _tree.transform.position.x);

        if(_distance < 10f)
        {                                   
            move();
        }
        if( canAttack() )
        {
            attack();
        }
        if(_hp <= 0)
        {
            death();
        }
    }

    IEnumerator AttackCooldown()
    {
        float _timeToAttack = 1f;

        while( _timeToAttack > 0f )
        {
            yield return null;
            _timeToAttack -= Time.deltaTime;
        }
        _attackReady = true;
    }

    IEnumerator BurnTime()
    {
        float _burnTime = 3f;
        while( _burnTime > 0 )
        {      
            _hp -= 5;
            Debug.Log("HP: " + _hp);
            yield return new WaitForSeconds(1);
            _burnTime -= Time.deltaTime;
        }
        _isBurning = false;
    }

    public void move()
    {
        if(_player.position.x > (_tree.transform.position.x + _attackRange - 1) )
        {
            _tree.transform.Translate(Vector2.right * _velocity * Time.deltaTime);
            _renderer.flipX = false;
        }
        else if(_player.position.x < (_tree.transform.position.x - _attackRange + 1) )
        {
            _tree.transform.Translate(Vector2.left * _velocity * Time.deltaTime);
            _renderer.flipX = true;
        }

    }

    public void attack()
    {
        Debug.Log( "hit!" );
        _attackReady = false;
        StartCoroutine( AttackCooldown() );
    }

    public bool canAttack()
    {
        if ( (_distance < _attackRange) && _attackReady == true)
            return true;
        else
            return false;
    }

    public void death()
    {
        Destroy( _tree );
    }

    public void afterBurn()
    { 
        StartCoroutine( BurnTime() );     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            _hp -= 50;
            Debug.Log("HP: " + _hp);
            if(_isBurning == false)
            {
                _isBurning = true;
                afterBurn();
            }     
            Destroy(collision.gameObject);
        }
    }
}

