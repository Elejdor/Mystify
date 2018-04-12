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
    

    bool _spellReady = true;

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
        Debug.Assert(_movement, "Missing object reference");
    }

    // Use this for initialization
    void Start()
    {
        InputManager.SetListener( this );
        InputManager.SetPlayerTransform( transform );
    }

    IEnumerator RefreshCooldown()
    {
        float _timeToCast = 1.0f;

        while ( _timeToCast > 0.0f )
        {
            yield return null;
            _timeToCast -= Time.deltaTime;
        }

        _spellReady = true;
    }

    public void OnControllerUpdate( InputManager input )
    {
        _arm.right = input._aimingDirection;
        HandleSpellsInput( input );
        HandleMovementInput( input );
    }

    void HandleSpellsInput( InputManager input )
    {
        if ( !_spellReady )
            return;
                                

        byte spell = 0;
        if ( input._cast0 )
            spell |= 1;

        if ( input._cast1 )
            spell |= 2;
        
        switch ( spell )
        {
            case 1:
                _fireball.Cast( input._aimingDirection );
                break;
            case 2:
                _wind.Cast( input._aimingDirection );
                break;
            case 3:
                _flamethrower.Cast();
                break;
        }
        if ( spell != 0 )
        {
            _spellReady = false;
            StartCoroutine( RefreshCooldown() );
        }
    }

    void HandleMovementInput(InputManager input)
    {                                 
        _movement.walk(input);                                               
        if( (_movement.isGrounded == true) && (input._jump == ButtonState.Pressed) )
            _movement.jump();  
    }

    public void OnControllGained()
    {
    }

    public void OnControllLost()
    {
    }
}
