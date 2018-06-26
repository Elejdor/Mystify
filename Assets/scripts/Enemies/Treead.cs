using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treead : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
        GameObject _tree;
    [SerializeField]
        Animator _anim;   
    [SerializeField]
        Transform _renderer;
    [SerializeField]
        GameObject UIManager;
    PlayerStats _playerStat;       
    GameObject _player;

    private float _velocity;
    private float _attackRange;
    private float _distance;
    private float _movementDirection;

    public int _hpMax;
    public float ratio;            
    public float _hp;
    public float _burnTime;
    public bool _isBurning;
    public bool _attackReady;
                                   
    bool _isLeft = true;

    void Start()
    {                            
        _hpMax = 200;
        _hp = _hpMax;
        _velocity = 8.5f;
        _burnTime = 4f;
        _attackRange = 6f;
        _attackReady = true;
        _isBurning = false;
        _player = GameObject.Find("Player");
        _playerStat = _player.GetComponent<PlayerStats>(); 
    }

    private void Update()
    {
        ratio = _hp / _hpMax;
        _distance = Mathf.Abs(_player.transform.position.x - _tree.transform.position.x);

        if( (_distance < 20f) || (_hp != _hpMax) )
        {                                   
            move();
        }
        if( canAttack() )
        {
            attack();
        }  
        if(_player.transform.position.x - _tree.transform.position.x < 0 && !_isLeft)
        {
            Flip();
        }
        else if(_player.transform.position.x - _tree.transform.position.x > 0 && _isLeft)
        {
            Flip();
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
        if(_player.transform.position.x > (_tree.transform.position.x + _attackRange - 1))
        {
            _tree.transform.Translate(Vector2.right * _velocity * Time.deltaTime);
            _movementDirection = 1f;
        }
        else if(_player.transform.position.x < (_tree.transform.position.x - _attackRange + 1))
        {
            _tree.transform.Translate(Vector2.left * _velocity * Time.deltaTime);
            _movementDirection = 1f;
        }
        else
            _movementDirection = 0f;

        _anim.SetFloat("Speed", _movementDirection);
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
        if((_distance < _attackRange) && _attackReady)
        {
            _anim.SetBool("Attack", true);   
            return true;
        }
        else
        {          
            _anim.SetBool("Attack", false);
            return false;
        }
    }
             
    public void afterBurn()
    { 
        StartCoroutine( BurnTime() );     
    }

    public void death()
    {                    
        Destroy(_tree);
        if(this.gameObject.name == "Treead")
        {
            //UIManager.GetComponent<UIOptions>().monologeEnd = false;
            //UIManager.GetComponent<UIOptions>().DialogLayout();
        }
    }

    public void Damage(float damage)
    {                                        
        this._hp -= damage;
        if(_hp <= 0)
            death();
    }

    void Flip()
    {
        _isLeft = !_isLeft;
        Vector3 scale = _renderer.localScale;
        scale.x *= -1;
        _renderer.localScale = scale;
    }

}

