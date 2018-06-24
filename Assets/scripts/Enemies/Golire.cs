using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golire : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
    private GameObject _golire;
    [SerializeField]
    private Transform _renderer;
    private GameObject _player;
    [SerializeField]
    private GameObject _castPoint;
    [SerializeField]
    private Mesh _sprites;
    [SerializeField]
    Animator _anim;

    private Vector2 _dir;
    private CastFireball _fire;
                         
    public float _hp = 50;
    private bool _canCast = true;

    public bool extinguished = false;
    bool _isLeft = true;

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
            _fire.Cast(_dir);

            _canCast = false;
            _anim.SetBool("Attack", false);
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

    void Flip()
    {
        _isLeft = !_isLeft;
        Vector3 scale = _renderer.localScale;
        scale.x *= -1;
        _renderer.localScale = scale;
    }

}
