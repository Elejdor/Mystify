using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScreen : MonoBehaviour
{
    [SerializeField]
    CanvasGroup _fader;

    private float _timer;

	// Use this for initialization
	void Start ()
    {
        _fader = GetComponent<CanvasGroup>();
        _fader.alpha = 0f;
        _timer = 1000;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _timer -= Time.deltaTime;
        if(_timer > 0)
        {
            StartCoroutine(fadeInOut(10));
        }

	}

    IEnumerator fadeInOut(float fadeTime)
    {
        while(fadeTime > 0)
        {
            _fader.alpha += 0.01f;
            yield return null;
            fadeTime -= Time.deltaTime;
        }

    }
}
