using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputManagerTest : MonoBehaviour, IInputListener {

    [SerializeField]
    Text _useGamepad;

    [SerializeField]
    Text _run;

    [SerializeField]
    Text _jump;

    [SerializeField]
    Text _cast0;

    [SerializeField]
    Text _cast1;

    void Awake()
    {
        InputManager.Init( transform );
    }

    void Start()
    {
        InputManager.SetListener( this );
    }

    void Update()
    {
        InputManager.Update();
    }

    public void OnControllGained()
    {
        Debug.Log( "Input attached." );
    }

    public void OnControllLost()
    {
        Debug.Log( "Input detached." );
    }

    public void OnControllerUpdate()
    {
        _useGamepad.text = "Use gamepad: " + InputManager._useGamepad.ToString();
        _run.text = "Run: " + InputManager._horizontal;
        _jump.text = "Jump: " + InputManager._jump;
        _cast0.text = "Cast 0: " + InputManager._cast0;
        _cast1.text = "Cast 1: " + InputManager._cast1;

        transform.right = InputManager._aimingDirection;
    }
}
