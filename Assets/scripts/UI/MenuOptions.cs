using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    [SerializeField]
    CanvasGroup _fader;
                         
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(fadeIn(5));
	}
	  
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(fadeOut(5));
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        StartCoroutine(fadeOut(5));
        Application.Quit();
    }

    IEnumerator fadeIn(float fadeTime)
    {
        while(fadeTime > 0)
        {
            _fader.alpha += 0.01f;
            yield return null;
            fadeTime -= Time.deltaTime;
        }                            
    }

    IEnumerator fadeOut(float fadeTime)
    {
        while(fadeTime > 0)
        {
            _fader.alpha -= 0.01f;
            yield return null;
            fadeTime -= Time.deltaTime;
        }   
    }
}
