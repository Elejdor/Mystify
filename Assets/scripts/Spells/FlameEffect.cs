using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameEffect : MonoBehaviour {

    [SerializeField]
    ParticleSystem _ps;

    bool _playing = false;
    public void Play()
    {
        if (!_playing )
        {
            _ps.Play( true );
            _playing = true;
        }
    }

    public void Stop()
    {
        if ( _playing )
        {
            _playing = false;
            _ps.Stop( true );
        }
    }
}
