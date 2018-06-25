using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRenderer : MonoBehaviour {

    [SerializeField]
    Anima2D.SpriteMeshInstance[] _renderers;

    [SerializeField]
    Color _coldColor;

    [SerializeField]
    Color _hotColor;

    Color _current;

    void Start()
    {
        SetHot( 1.0f );
    }

    public void SetHot( float val )
    {
        val = Mathf.Clamp01( val );
        _current = Color.Lerp( _coldColor, _hotColor, val );
        UseCurrentColor();
    }

    internal void SetTransparency( float alpha )
    {
        alpha = Mathf.Clamp01( alpha );
        _current.a = alpha;

        UseCurrentColor();
    }

    void UseCurrentColor()
    {
        foreach ( Anima2D.SpriteMeshInstance rend in _renderers )
        {
            rend.color = _current;
        }
    }
}
