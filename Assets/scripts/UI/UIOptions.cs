using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptions : MonoBehaviour
{

    [SerializeField]
        CanvasGroup _fader;
    //[SerializeField]
    //AudioSource _song;
    [SerializeField]
    TextManager textManager;

    public bool monologeEnd = false;
    private static bool created = false;
    private bool inCoroutine = false;

    void Awake()
    {
        if(!created)
        {                                
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        monologeEnd = false;
        _fader.alpha = 1f;
    }

    private void Update()
    {
        StartCoroutine(fadeOut(10));   
        
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(fadeOut(5));
        SceneManager.LoadScene(sceneName);
        StartCoroutine(fadeIn(5));       
    }

    public IEnumerator MonologueStart(TextStates textStates)
    {
        while(inCoroutine)
            yield return new WaitForSeconds(0.1f);
        DialogLayout(); 
        textManager.currentState = textStates;
        yield return new WaitForSeconds(15f);
        Debug.Log("MONOLOGUE!");
        monologeEnd = true;
        textManager.currentState = TextStates.NoText;
    }

    public void DialogLayout()
    {
        /*inCoroutine = true;
        StartCoroutine(fadeIn(3f, 0.8f));    
        Time.timeScale = 0f;
        if(monologeEnd)
        {
            monologeEnd = false;
            Time.timeScale = 1f;
            StartCoroutine(fadeOut(3f));
        }
        inCoroutine = false;*/
    }

    public void QuitGame()
    {
        StartCoroutine(fadeOut(5));
        Application.Quit();
    }

    IEnumerator fadeIn(float fadeTime, float maxAlpha = 1f)
    {
        inCoroutine = true;
        while(fadeTime > 0)
        {
            if(_fader.alpha <= maxAlpha)
                _fader.alpha += 0.01f;
            //_song.volume -= 0.01f;
            yield return null;
            fadeTime -= Time.deltaTime;
        }
        inCoroutine = false;
    }

    IEnumerator fadeOut(float fadeTime, float minAlpha = 0f)
    {
        inCoroutine = true;
        while(fadeTime > 0)
        {
            if(_fader.alpha >= minAlpha)
                _fader.alpha -= 0.01f;
            //_song.volume += 0.01f;
            yield return null;
            fadeTime -= Time.deltaTime;
        }
        inCoroutine = false;
    }
}
