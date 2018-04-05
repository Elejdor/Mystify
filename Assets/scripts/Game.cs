using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Awake()
    {
        InputManager.Init();
    }

    void Update()
    {
        InputManager.GlobalUpdate();
    }

    ~Game()
    {
        InputManager.SetListener( null );
        InputManager.SetPlayerTransform( null );
    }
}