using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public enum ButtonState
{
    Idle,
    Released,
    Pressed
}

public interface IInputListener
{
    void OnControllGained();
    void OnControllLost();
    void OnControllerUpdate( InputManager input );
}

public class InputManager
{
    static InputManager s_input;
    public Vector2 _aimingVector { get; private set; }
    public Vector2 _aimingDirection { get; private set; }
    public float _horizontal { get; private set; }
    public ButtonState _jump { get; private set; }
    public bool _cast0 { get; private set; }
    public bool _cast1 { get; private set; }
    public bool _useGamepad { get; private set; }

    GamePadState _gs;
    Transform _playerTransform;
    IInputListener _listener;
    Vector3 _wsMousePos;
    Vector3 _ssMousePos;
                                  

    public static void Init()
    {
        if ( s_input != null )
            return;

        InputManager input = new InputManager();

        input._gs = GamePad.GetState( 0, GamePadDeadZone.Circular );
        input._useGamepad = input._gs.IsConnected;
        s_input = input;
    }

    public static void GlobalUpdate()
    {
        if ( s_input != null )
            s_input.UpdateInternal();
    }

    void UpdateInternal()
    {
        ResetInput();
        _gs = GamePad.GetState( 0, GamePadDeadZone.Circular );

        if ( JumpPressed() )
            _jump = ButtonState.Pressed;

        _horizontal = GetHorizontalAxis();
        _cast0 = IsCasting( 0 );
        _cast1 = IsCasting( 1 );

        if ( _playerTransform )
        {
            _aimingVector = GetAimingVector( _playerTransform );
            if ( !_gs.IsConnected )
                _aimingDirection = _aimingVector.normalized;
            else if ( _aimingVector.sqrMagnitude > 0.1f )
                _aimingDirection = _aimingVector.normalized;
        }                                     

        if ( _listener != null )
            _listener.OnControllerUpdate( this );
    }

    void ResetInput()
    {
        _jump = ButtonState.Idle;
    }

    public static void SetListener( IInputListener listener )
    {
        if ( s_input != null )
            s_input.SetListenerInternal( listener );
    }

    public static bool IsController( IInputListener obj )
    {
        return obj.Equals( s_input._listener );
    }

    public static void SetPlayerTransform( Transform player )
    {
        if ( s_input != null )
            s_input._playerTransform = player;
    }

    void SetListenerInternal( IInputListener listener )
    {
#if UNITY_EDITOR
        if ( Settings._verbose )
            Debug.Log( "Input listener: " + listener.GetType().ToString() );
#endif

        if ( _listener != null )
            _listener.OnControllLost();

        _listener = listener;
        if ( _listener != null )
            _listener.OnControllGained();
    }

    bool JumpReleased()
    {
        if ( !( Input.GetKey( KeyCode.Space ) ||
                Input.GetKey( KeyCode.W ) ||
                Input.GetKey( KeyCode.UpArrow ) ) &&
                _gs.Buttons.A == XInputDotNetPure.ButtonState.Released )
            return true;

        return false;
    }

    bool JumpPressed()
    {
        if ( Input.GetKey( KeyCode.Space ) ||
             Input.GetKey( KeyCode.W ) ||
             Input.GetKey( KeyCode.UpArrow ) )
        {
            _useGamepad = false;
            return true;
        }
        else if ( _gs.Buttons.A == XInputDotNetPure.ButtonState.Pressed )
        {
            _useGamepad = true;
            return true;
        }

        return false;
    }

    float GetHorizontalAxis()
    {
        if ( Input.GetKey( KeyCode.RightArrow ) || Input.GetKey( KeyCode.D ) )
        {
            _useGamepad = false;
            return 1.0f;
        }

        if ( Input.GetKey( KeyCode.LeftArrow ) || Input.GetKey( KeyCode.A ) )
        {
            _useGamepad = false;
            return -1.0f;
        }

        if ( _gs.ThumbSticks.Left.X > 0.01f )
        {
            _useGamepad = true;
        }
        return _gs.ThumbSticks.Left.X;
    }

    Vector2 GetAimingVector( Transform target )
    {

        Vector2 result = Vector2.zero;

        if ( target )
        {
            if ( _useGamepad )
            {
                return new Vector2( s_input._gs.ThumbSticks.Right.X, s_input._gs.ThumbSticks.Right.Y );
            }
            else
            {
                _wsMousePos = Input.mousePosition;
                _ssMousePos = Camera.main.WorldToScreenPoint( target.position );
                result = _wsMousePos - _ssMousePos;
            }
        }

        return result;
    }

    bool IsCasting( int spellId )
    {
        const float threshold = 0.5f;

        switch ( spellId )
        {
            case 0:
                if ( s_input._gs.Triggers.Left > threshold ) {
                    _useGamepad = true;
                    return true;
                }
                break;
            case 1:
                if ( s_input._gs.Triggers.Right > threshold ) {
                    _useGamepad = true;
                    return true;
                }
                break;
            default:
                return false;
        }

        if ( Input.GetMouseButton( spellId ) )
        {
            _useGamepad = false;
            return true;
        }

        return false;
    }
}