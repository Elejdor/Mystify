using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager m_instance = null;

    AudioSource[] m_sfxSources;

    [SerializeField]
    GameObject m_sfxRoot;

    [SerializeField]
    AudioSource m_ambientSource;

    [SerializeField]
    List< SoundEntry > m_soundEffects;

    Queue< AudioClip > m_clipsQueue = new Queue< AudioClip >( 5 );

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
        if (m_instance)
            DestroyImmediate(gameObject);
        else
        {
            m_instance = this;
            m_sfxSources = m_sfxRoot.GetComponentsInChildren<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void Play(SfxType sfx, bool randomPitch = false)
    {
        foreach ( SoundEntry entry in m_instance.m_soundEffects )
        {
            if ( entry.GetEffectType() == sfx )
            {
                m_instance.InternalPlay( entry.GetRandomClip(), randomPitch);
                return;
            }
        }

        Debug.LogWarning( "No such sfx." );
    }

    AudioSource FindSfxSource()
    {
        foreach ( AudioSource src in m_sfxSources )
        {
            if ( src.isPlaying == false )
            {
                src.pitch = 1.0f;
                return src;
            }
        }

        return null;
    }

    void InternalPlay(AudioClip clip, bool randomPitch)
    {
        AudioSource audio = FindSfxSource();
        if (audio)
        {
            if (randomPitch)
                audio.pitch = UnityEngine.Random.Range( 0.8f, 1.2f );
            audio.PlayOneShot(clip);
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
