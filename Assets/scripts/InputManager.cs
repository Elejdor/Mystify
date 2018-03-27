using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class InputManager
{
    static GamePadState _gs;

    static void GlobalUpdate()
    {
        _gs = GamePad.GetState( 0 );
    }

    public static bool JumpUp()
    {
        if ( Input.GetKeyUp( KeyCode.Space ) )
            return true;

        if ( _gs.Buttons.A == ButtonState.Released )
            return true;

        return false;
    }

    public static bool JumpDown()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
            return true;

        if ( _gs.Buttons.A == ButtonState.Pressed )
            return true;

        return false;
    }

    public static float HorizontalRun()
    {
        if ( Input.GetKey( KeyCode.RightArrow ) || Input.GetKey( KeyCode.D ) )
            return 1.0f;

        if ( Input.GetKey( KeyCode.LeftArrow ) || Input.GetKey( KeyCode.A ) )
            return -1.0f;

        return _gs.ThumbSticks.Left.X;
    }
}