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
                         
    public float _hp = 50;
    public bool extinguished = false;


    // Use this for initialization
    void Start ()
    {
        _fire = GetComponent<CastFireball>();
        _player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
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
        Destroy(_golire);
    }

    public void Damage(float damage)
    {
        Debug.Log("golireHP: " + _hp);
        _hp -= damage;
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
