using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager m_instance = null;

    AudioSource[] m_sfxSources;
    AudioSource[] m_ambientSources;

    [SerializeField]
    GameObject m_sfxRoot;

    [SerializeField]
    GameObject m_ambientRoot;

    [SerializeField]
    List< SoundEntry > m_soundEffects;

    Queue< AudioClip > m_clipsQueue = new Queue< AudioClip >( 5 );

    bool m_processinQueue = false;

    [Serializable]
    class SoundEntry
    {
        [SerializeField]
        SfxType m_effectType;

        [SerializeField]
        AudioClip[] m_clips;

        public AudioClip GetRandomClip()
        {
            if ( m_clips.Length == 0 )
                return null;

            int clipIndex = UnityEngine.Random.Range( 0, m_clips.Length );
            return m_clips[clipIndex];
        }

        public SfxType GetEffectType() { return m_effectType; }
    }

    // Use this for initialization
    void Start()
    {
        m_instance = this;
        m_sfxSources = m_sfxRoot.GetComponentsInChildren<AudioSource>();
        m_ambientSources = m_ambientRoot.GetComponentsInChildren<AudioSource>();
        DontDestroyOnLoad( gameObject );
    }

    public static void Play( SfxType sfx, AudioSource audio = null )
    {
        foreach ( SoundEntry entry in m_instance.m_soundEffects )
        {
            if ( entry.GetEffectType() == sfx )
            {
                InternalPlay( entry.GetRandomClip(), audio );
                return;
            }
        }

        Debug.LogWarning( "No such sfx." );
    }

    static void InternalPlay( AudioClip clip, AudioSource audio )
    {
        if ( audio )
        {
            audio.PlayOneShot( clip );
        }
        else
        {
            m_instance.PlayAsStaticSource( clip );
        }
    }

    void PlayAsStaticSource( AudioClip clip )
    {
        foreach ( AudioSource audio in m_sfxSources )
        {
            if ( !audio.isPlaying )
            {
                audio.PlayOneShot( clip );
                break;
            }
        }
    }
}

public enum SfxType
{
    Fireball,
    FireExplosion,
    FlameThrower,
    MvSteps,
    MvJump,
    MvLand
}
