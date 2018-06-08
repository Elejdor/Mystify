using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour
{
    [SerializeField]
    private GameObject _anger;
    // [SerializeField]
    // private SpriteRenderer _renderer;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _castPoint;
    [SerializeField]
    private GameObject _lance;
    private Vector2 _dir;
    private CastFireball _fire;

    [SerializeField]
    private float _hp = 200;
    [SerializeField]
    private float castCooldown = 2f;
    [SerializeField]
    private float lanceTime = 0.5f;
    [SerializeField]
    private float lanceCooldown = 10f;
    private bool _canCast = true;
    private bool _canLance = true;
    // Use this for initialization
    void Start()
    {
        _fire = GetComponent<CastFireball>();
    }

    // Update is called once per frame
    void Update()
    {
        aim();
        if (Mathf.Abs(_player.transform.position.x - _anger.transform.position.x) < 30)
            throwFireball();
        if (_canLance == true)
            StartCoroutine(Lance());
    }



    public void aim()
    {
        _dir = _player.transform.position - _anger.transform.position;
        _dir.Normalize();
        //if (_player.position.x > _anger.transform.position.x)
        //{
        //    _castPoint.transform.position = new Vector2((_anger.transform.position.x + 4), _anger.transform.position.y);
        //    _renderer.flipX = true;
        //}
        //else
        //{
        //    _castPoint.transform.position = new Vector2(_anger.transform.position.x - 4, _anger.transform.position.y);
        //    _renderer.flipX = false;
        //}
    }

    public void throwFireball()
    {
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
        _hp -= damage;
        if (_hp <= 0)
            death();
    }

    IEnumerator FireballCooldown()
    {
        yield return new WaitForSeconds(castCooldown);
        _canCast = true;
    }

    IEnumerator Lance()
    {
        _lance.transform.position = new Vector3(_lance.transform.position.x - 5, _lance.transform.position.y, _lance.transform.position.z);
        yield return new WaitForSeconds(lanceTime);
        _lance.transform.position = new Vector3(_lance.transform.position.x + 5, _lance.transform.position.y, _lance.transform.position.z);
        _canLance = false;
        StartCoroutine("LanceCooldown");
        
    }

    IEnumerator LanceCooldown()
    {
        yield return new WaitForSeconds(lanceCooldown);
        _canLance = true;
        
    }
}