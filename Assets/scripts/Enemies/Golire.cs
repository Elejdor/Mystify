using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golire : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
        GameObject _golire;
    [SerializeField]
        Transform _renderer;
    [SerializeField]
        GameObject _castPoint;  
    [SerializeField]
        Animator _anim;

    private GameObject _player;      
    private Vector2 _dir;
    private CastFireball _fire;
    private bool _canCast = true;
    private bool _isLeft = true;
                         
    float _maxHp = 50;
    public float _hp = 50;
    public bool extinguished = false;
    bool _dying = false;

    LavaRenderer _rend;

    // Use this for initialization
    void Start ()
    {
        _fire = GetComponent<CastFireball>();
        _player = GameObject.Find("Player");
        _rend = GetComponentInChildren<LavaRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ( _dying )
            return;

        aim();
        if( Mathf.Abs(_player.transform.position.x - _golire.transform.position.x) < 30 )
            throwFireball();
        extinguish();
	}

    public void extinguish()
    {
        if(extinguished)
        {
            Damage(25 * Time.deltaTime);   
            StartCoroutine(ExtinguishTime(5f));
        }      
            
    }

    public void aim()
    {
        _dir = _player.transform.position - _golire.transform.position;
        _dir.Normalize();
        if( (_player.transform.position.x > _golire.transform.position.x) && _isLeft)
            Flip();
        else if((_player.transform.position.x <= _golire.transform.position.x) && !_isLeft)
            Flip();
    }

    public void throwFireball()
    {
        if(_canCast)
        {
            _anim.SetBool("Attack", true);
            if(_anim.GetCurrentAnimatorStateInfo(0).IsName("gorille_attack"))
                _anim.SetBool("Attack", false);
            StartCoroutine(beforeAnim());      
            
            _canCast = false;                         
            StartCoroutine(FireballCooldown());
        }                                 
    }   

    public void death()
    {
        if ( _dying )
            return;

        _dying = true;
        StartCoroutine( DeathSequence() );
    }

    IEnumerator DeathSequence()
    {
        float duration = 0.3f;
        float time = duration;

        // fade out
        while ( time > 0.0f )
        {
            time -= Time.deltaTime;
            _rend.SetTransparency( time / duration );
            yield return null;
        }
        Destroy( _golire );
    }

    void SetHp(float val)
    {
        _hp = val;
        if ( _hp > _maxHp )
            _hp = _maxHp;
        else if ( _hp < 0 )
            death();

        _rend.SetHot( _hp / _maxHp );
    }

    public void Heal( float amount )
    {
        SetHp( _hp + amount );
    }

    public void Damage(float damage)
    {
        SetHp( _hp - damage );
    }

    void Flip()
    {
        _isLeft = !_isLeft;
        Vector3 scale = _renderer.localScale;
        scale.x *= -1;
        _renderer.localScale = scale;
    }

    IEnumerator beforeAnim()
    {
        yield return new WaitForSeconds(0.7f);
        _fire.Cast(_dir);                     
    }

    IEnumerator FireballCooldown()
    {
        float castCooldown;
        if(extinguished)
            castCooldown = 5f;
        else
            castCooldown = 3f;                    
        yield return new WaitForSeconds(castCooldown);
        _canCast = true;
    }

    public IEnumerator ExtinguishTime(float extTime = 5f)
    {                                                   
        yield return new WaitForSeconds(extTime);
        extinguished = false;
    }
}
