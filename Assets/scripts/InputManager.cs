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
    void OnControllerUpdate();
}

public class InputManager
{
    public static Vector2 _aimingVector { get; private set; }
    public static Vector2 _aimingDirection { get; private set; }
    public static float _horizontal { get; private set; }
    public static ButtonState _jump { get; private set; }
    public static bool _cast0 { get; private set; }
    public static bool _cast1 { get; private set; }

    static GamePadState _gs;
    static Transform _playerTransform;
    static IInputListener _listener;
    public static bool _useGamepad { get; private set; }

    public static void Init( Transform playerTransform = null )
    {
        _playerTransform = playerTransform;
        SetListener( null );

        _gs = GamePad.GetState( 0, GamePadDeadZone.Circular );
        _useGamepad = _gs.IsConnected;
    }

    public static void Update()
    {
        ResetInput();
        _gs = GamePad.GetState( 0, GamePadDeadZone.Circular );

        if ( Helper.JumpPressed() )
            _jump = ButtonState.Pressed;

        _horizontal = Helper.GetHorizontalAxis();
        _cast0 = Helper.IsCasting( 0 );
        _cast1 = Helper.IsCasting( 1 );

        if ( _playerTransform )
        {
            _aimingVector = Helper.GetAimingVector( _playerTransform );
            if ( !_gs.IsConnected )
                _aimingDirection = _aimingVector.normalized;
            else if ( _aimingVector.sqrMagnitude > 0.1f )
                _aimingDirection = _aimingVector.normalized;
        }

        if ( _listener != null )
            _listener.OnControllerUpdate();
    }


    static void ResetInput()
    {
        _jump = ButtonState.Idle;
    }

    public static void SetListener( IInputListener listener )
    {
        if ( _listener != null )
            _listener.OnControllLost();

        _listener = listener;
        if ( _listener != null )
            _listener.OnControllGained();
    }

    static class Helper
    {
        public static bool JumpReleased()
        {
            if ( !( Input.GetKey( KeyCode.Space ) ||
                    Input.GetKey( KeyCode.W ) ||
                    Input.GetKey( KeyCode.UpArrow ) ) &&
                    _gs.Buttons.A == XInputDotNetPure.ButtonState.Released )
                return true;

            return false;
        }

        public static bool JumpPressed()
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

        public static float GetHorizontalAxis()
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

        static Vector3 _mousePosCache;
        static Vector3 _ssPosCache;
        public static Vector2 GetAimingVector( Transform target )
        {
            Vector2 result = Vector2.zero;

            if ( target )
            {
                if ( _useGamepad )
                {
                    return new Vector2( _gs.ThumbSticks.Right.X, _gs.ThumbSticks.Right.Y );
                }
                else
                {
                    _mousePosCache = Input.mousePosition;
                    _ssPosCache = Camera.main.WorldToScreenPoint( target.position );
                    result = _mousePosCache - _ssPosCache;
                }
            }

            return result;
        }

        public static bool IsCasting( int spellId )
        {
            const float threshold = 0.5f;

            switch ( spellId )
            {
                case 0:
                    if ( _gs.Triggers.Left > threshold )
                    {
                        _useGamepad = true;
                        return true;
                    }
                    break;
                case 1:
                    if ( _gs.Triggers.Right > threshold )
                    {
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
}