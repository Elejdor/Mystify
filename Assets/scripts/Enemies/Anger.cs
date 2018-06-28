using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour
{
    [SerializeField]
        private GameObject _anger;
    [SerializeField]
        private GameObject _player;
    [SerializeField]
        private GameObject _castPoint;
    [SerializeField]
        private GameObject _lance;
    [SerializeField]
        private float lanceOffset = 100f;
    [SerializeField]
        Animator _anim;
    private Vector2 _dir;
    private CastFireball _fire;

    
        public float _hp = 200;
    public float _hpMax;
    [SerializeField]
        private float castCooldown = 2f;
    [SerializeField]
        private float lanceTime = 0.5f;
    [SerializeField]
        private float lanceCooldown = 10f;
    private bool _canCast = true;
    private bool _canLance = false;

    public bool _canRegen = true;
    private float _distance;
    [SerializeField]
        private float _velocity = 8.5f;
    [SerializeField]
        private float _attackRange = 30f;
    private float _movementDirection;

    bool b1 = true;
    bool b2 = true;
                                                
    void Start()
    {
        _hpMax = _hp;
        _canLance = true;

    _fire = GetComponent<CastFireball>();
    }

    
    void Update()
    {
        _distance = Mathf.Abs(_player.transform.position.x - _anger.transform.position.x);
        if ((_distance < 40f) || (_hp != _hpMax))
        {
            move();
        }
        aim();
        if (Mathf.Abs(_player.transform.position.x - _anger.transform.position.x) < 45)
            throwFireball();

        
        if (_canLance == true)
        {
            StartCoroutine(Lance());
            Wait(2f);
        }
        

        Regenerating();
    }

    public void move()
    {
        if (_player.transform.position.x > (_anger.transform.position.x + _attackRange - 1))
        {
            _anger.transform.Translate(Vector2.right * _velocity * Time.deltaTime);
            _movementDirection = 1f;
        }
        else if (_player.transform.position.x < (_anger.transform.position.x - _attackRange + 1))
        {
            _anger.transform.Translate(Vector2.left * _velocity * Time.deltaTime);
            _movementDirection = 1f;
        }
        else
            _movementDirection = 0f;

        _anim.SetFloat("speed", _movementDirection);
    }

    void Regenerating()
    {
        if (_canRegen && (_hp >= 0) && ((transform.position.x - _player.transform.position.x) < 25))
        {
            Damage(-20 * Time.deltaTime);
        }
        else
            StartCoroutine(RegenerationTime());
    }

    public void aim()
    {
        _dir = _player.transform.position - _castPoint.transform.position;
        _dir.Normalize();
    }

    public void throwFireball()
    {
        _anim.SetBool("fireball", _canCast);
        Wait(3f);
        if (_canCast)
        {
            _fire.Cast(_dir);
            _canCast = false;
            StartCoroutine("FireballCooldown");
        }
    }

    public void death()
    {
        Destroy(_anger);
    }

    public void Damage(float damage)
    {
        Debug.Log("angerHP: " + _hp);
        _hp += damage;
        if (_hp > _hpMax)
            _hp = _hpMax;
        if (_hp <= 0)
            death();
    }

    IEnumerator Wait(float time)
    {
        while(time > 0f)
        {
            yield return null;
            time -= Time.deltaTime;
        }
        _anim.SetBool("lance", false);
    }

    IEnumerator FireballCooldown()
    {
        yield return new WaitForSeconds(castCooldown);
        _canCast = true;
    }

    IEnumerator Lance()
    {            
        if(b1)
        {
            _anim.SetBool("lance", true);
            yield return new WaitForSeconds(0.8f);
            _canLance = false;
            _lance.transform.position = new Vector3(_lance.transform.position.x - lanceOffset, _lance.transform.position.y, _lance.transform.position.z);
            yield return new WaitForSeconds(lanceTime);
            _lance.transform.position = new Vector3(_lance.transform.position.x + lanceOffset, _lance.transform.position.y, _lance.transform.position.z);
            yield return new WaitForSeconds(lanceCooldown);
            _anim.SetBool("lance", false);
            b1 = false;
        }
        else
        {
            yield return new WaitForSeconds(lanceCooldown);
            b1 = true;
        }    
        _anim.SetBool("lance", true);
        yield return new WaitForSeconds(0.8f);
        _canLance = false;
        //_lance.transform.position = new Vector3(_lance.transform.position.x - lanceOffset, _lance.transform.position.y, _lance.transform.position.z);
        yield return new WaitForSeconds(lanceTime);
        _anim.SetBool("lance", false);
        //_lance.transform.position = new Vector3(_lance.transform.position.x + lanceOffset, _lance.transform.position.y, _lance.transform.position.z);
        yield return new WaitForSeconds(lanceCooldown);
        _canLance = true;                        
    }


    public IEnumerator RegenerationTime()
    {
        float regenTime = 5f;
        while (regenTime > 0f)
        {
            yield return null;
            regenTime -= Time.deltaTime;
        }
        _canRegen = true;
    }
}