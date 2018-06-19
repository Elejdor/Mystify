using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadingScreen : MonoBehaviour
{
    [SerializeField]
    CanvasGroup _fader;
    [SerializeField]
    AudioSource _song;

	// Use this for initialization
	void Start ()
    {
        _fader = GetComponent<CanvasGroup>();
        _fader.alpha = 0f;  

        StartCoroutine(gameTime(90));
    }

    IEnumerator fadeIn(float fadeTime)
    {
        while(fadeTime > 0)
        {
            _fader.alpha += 0.01f;
            _song.volume -= 0.01f;
                yield return null;
            fadeTime -= Time.deltaTime;
        }
        //StartCoroutine(fadeOut(5f));  
        SceneManager.LoadScene("EndScene");
    }
    IEnumerator fadeOut(float fadeTime)
    {
        while(fadeTime > 0)
        {
            _fader.alpha -= 0.01f;
            yield return null;
            fadeTime -= Time.deltaTime;
        }
        SceneManager.LoadScene("EndScene");
    }

    IEnumerator gameTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(fadeIn(5));
    }

}
