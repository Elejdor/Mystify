using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInputListener
{
    [SerializeField]
    Transform _arm;

    CastFireball _fireball;
    CastWind _wind;
    CastFlamethrower _flamethrower;
    CharacterMovement _movement;

    [SerializeField]
    SimpleCameraFollow _camera;

    int _prevSpellInput = 0;

    // cooldowns
    float _projectileCld = 0.0f;
    float _flameThrowerCld = 0.0f;

    const float c_projectileCld = 1.0f;
    const float c_flameThrowerCld = 1.0f;

    bool _castingFlamethrower = false;

    void Awake()
    {
        Debug.Assert( _arm, "Missing object reference" );

        _fireball = GetComponent<CastFireball>();
        _wind = GetComponent<CastWind>();
        _flamethrower = GetComponent<CastFlamethrower>();
        _movement = GetComponent<CharacterMovement>();

        Debug.Assert( _fireball, "Missing object reference" );
        Debug.Assert( _wind, "Missing object reference" );
        Debug.Assert( _flamethrower, "Missing object reference" );
        Debug.Assert( _movement, "Missing object reference" );
    }

    // Use this for initialization
    void Start()
    {
        InputManager.SetListener( this );
        InputManager.SetPlayerTransform( transform );
    }

    void Update()
    {
        RefreshCooldowns();
    }

    void RefreshCooldowns()
    {
        if ( _flameThrowerCld > 0.0f )
            _flameThrowerCld -= Time.deltaTime;

        if ( _projectileCld > 0.0f )
            _projectileCld -= Time.deltaTime;
    }

    public void OnControllerUpdate( InputManager input )
    {
        _arm.right = input._aimingDirection;
        _camera.SetAiming( input._aimingVector );
        HandleSpellsInput( input );
        HandleMovementInput( input );
    }

    void HandleSpellsInput( InputManager input )
    {
        byte spell = 0;
        if ( input._cast0 )
            spell |= 1;

        if ( input._cast1 )
            spell |= 2;

        if ( _prevSpellInput != spell )
        { // 1 frame delay
            _prevSpellInput = spell;
            return;
        }

        if ( spell == 1 || spell == 2 )
        { // fireball or wind
            CastProjectile( spell, input._aimingDirection );
        }

        if ( spell != 3 )
        {
            _castingFlamethrower = false;
            _flamethrower.Stop();
        }
        else if ( spell == 3 || _castingFlamethrower )
        { // flamethrower
            CastFlamethrower();
        }
    }

    void CastFlamethrower()
    {
        if ( _flameThrowerCld <= 0.0f || _castingFlamethrower )
        {
            _flamethrower.Cast();
            _castingFlamethrower = true;
            _flameThrowerCld = c_flameThrowerCld;

            if ( _projectileCld < 0.5f * c_projectileCld )
            {
                _projectileCld = 0.5f * c_projectileCld;
            }
        }
    }

    void CastProjectile( int spell, Vector2 direction )
    {
        if ( _projectileCld <= 0.0f )
        {
            switch ( spell )
            {
                case 1:
                    _fireball.Cast( direction );
                    break;
                case 2:
                    _wind.Cast( direction );
                    break;
            }

            _projectileCld = c_projectileCld;
            _flameThrowerCld = c_projectileCld;
        }
    }

    void HandleMovementInput( InputManager input )
    {
        _movement.handleInput( input );
    }

    public void OnControllGained()
    {
    }

    public void OnControllLost()
    {
    }
}
