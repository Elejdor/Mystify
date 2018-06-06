using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golire : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
    private GameObject _golire;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject _castPoint;

    private Vector2 _dir;
    private CastFireball _fire;
                         
    private float _hp = 200;
    private bool _canCast = true;

    public bool extinguished = false;  
            
	// Use this for initialization
	void Start ()
    {
        _fire = GetComponent<CastFireball>(); 
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
        _dir = _player.position - _golire.transform.position;
        _dir.Normalize();
        if(_player.position.x > _golire.transform.position.x)
        {
            _castPoint.transform.position = new Vector2( (_golire.transform.position.x + 4), _golire.transform.position.y);
            _renderer.flipX = true;
        }
        else
        {
            _castPoint.transform.position = new Vector2(_golire.transform.position.x - 4, _golire.transform.position.y);
            _renderer.flipX = false;
        }
    }

    public void throwFireball()
    {
        if(_canCast)
        {
            _fire.Cast(_dir);
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
