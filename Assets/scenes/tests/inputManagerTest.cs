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
        InputManager.Init();
    }

    void Start()
    {
        InputManager.SetListener( this );
        InputManager.SetPlayerTransform( transform );
    }

    void Update()
    {
        InputManager.GlobalUpdate();
    }

    public void OnControllGained()
    {
        Debug.Log( "Input attached." );
    }

    public void OnControllLost()
    {
        Debug.Log( "Input detached." );
    }

    public void OnControllerUpdate( InputManager input )
    {
        _useGamepad.text = "Use gamepad: " + input.ToString();
        _run.text = "Run: " + input._horizontal;
        _jump.text = "Jump: " + input._jump;
        _cast0.text = "Cast 0: " + input._cast0;
        _cast1.text = "Cast 1: " + input._cast1;

        transform.right = input._aimingDirection;
    }
}
