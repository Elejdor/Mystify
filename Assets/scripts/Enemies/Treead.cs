using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treead : MonoBehaviour, IDamageable<int>
{
    [SerializeField]
    GameObject _tree;
    [SerializeField]
    Transform _player;
    [SerializeField]
    SpriteRenderer _renderer;   
    PlayerStats _playerStat;

    private int _hpMax;
    private int _hp;

    private float _velocity;
    private float _attackRange;
    private float _distance;

    public float _burnTime;
    public bool _isBurning;
    public bool _attackReady;  

   


    void Start()
    {                            
        _hpMax = 250;
        _hp = _hpMax;
        _velocity = 2f;
        _burnTime = 4f;
        _attackRange = 3f;
        _attackReady = true;
        _isBurning = false;
        _playerStat = _player.GetComponent<PlayerStats>();
    }

    private void Update()
    {   
        _distance = Mathf.Abs(_player.position.x - _tree.transform.position.x);

        if( (_distance < 10f) || (_hp != _hpMax) )
        {                                   
            move();
        }
        if( canAttack() )
        {
            attack();
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
        while(_burnTime > 0)
        {
            Damage(5);                  
            yield return new WaitForSeconds(1);
            _burnTime -= 1;
        }                   
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
        _playerStat.Damage(50);
        _playerStat._canRegen = false;
        _attackReady = false;
        StartCoroutine( AttackCooldown() );    
    }

    public bool canAttack()
    {
        if ( (_distance < _attackRange) && _attackReady)
            return true;
        else
            return false;
    }

    public void afterBurn()
    { 
        StartCoroutine( BurnTime() );     
    }

    public void death()
    {                    
        Destroy(_tree);
    }

    public void Damage(int damage)
    {
        Debug.Log("treeadHP: " + _hp);
        _hp -= damage;
        if(_hp <= 0)
            death();
    }
    
}

