﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeze : MonoBehaviour, IDamageable<float>
{                                
    [SerializeField]
        Rigidbody2D _breezePos;       
    [SerializeField]
        GameObject _breeze;

    GameObject _player;
    PlayerStats player;
    Vector2 _dir;

    private float _hp;
    private float _speed;

    void Start()
    {
        _hp = 5f;
        _speed = 1.5f;
        _breezePos = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        fly();
    }

    public void fly()
    {
        // Rotating Breeze
        Vector3 dirBreeze = transform.position - _player.transform.position;
        float angle = Mathf.Atan2(dirBreeze.y, dirBreeze.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // Moving Breeze
        _dir = _player.transform.position - _breeze.transform.position;
        _breezePos.velocity = _dir * _speed;                           
    }
                               
    public void death()
    {
        Destroy(_breeze);
    }


    public void Damage(float damage)
    {
        Debug.Log("breezeHP: " + _hp);
        _hp -= damage;
        if (_hp <= 0)
            death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerStats>();

        if (collision.gameObject.layer == 9)
        {
            death();
            player.Damage(20);
            player._canRegen = false;
            Shake.canShake = true;
        }
    }
}
