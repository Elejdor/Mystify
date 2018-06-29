using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptions : MonoBehaviour
{
    static UIOptions m_instance = null;

    [SerializeField]
        CanvasGroup _fader;  
    [SerializeField]
        TextManager textManager;

    public bool monologeEnd = false;
    private static bool created = false;
    private bool inCoroutine = false;

    void Awake()
    {
        if(!created)
        {                                
            //DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        monologeEnd = false;
        _fader.alpha = 1f;
        if(m_instance)
            DestroyImmediate(gameObject);
        else
        {
            m_instance = this;                                                  
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        StartCoroutine(fadeOut(10)); 
        //DialogLayout(TextStates.Epilogue);
    }

    public static void ChangeScene(string sceneName)
    {    
        //m_instance.StartCoroutine(m_instance.fadeOut(5));
        SceneManager.LoadScene(sceneName);
        //m_instance.StartCoroutine(m_instance.fadeIn(5));       
    }

    public IEnumerator MonologueStart(TextStates textStates, float lenght = 5f)
    {                                             
        textManager.currentState = textStates;
                              
        while(lenght >= 0)
        {    
            yield return null;
            lenght -= Time.deltaTime;
        }
        monologeEnd = true;
        textManager.currentState = TextStates.NoText;
    }

    public void DialogLayout(TextStates textState)
    {                                          
        StartCoroutine(fadeIn(3f, 0.8f));      
        Time.timeScale = 0f;
        StartCoroutine(MonologueStart(textState));
        if(monologeEnd)
        {
            Time.timeScale = 1f;                              
            StartCoroutine(fadeOut(3f));                
        }                                         
    }

    public void QuitGame()
    {
        StartCoroutine(fadeOut(5));
        Application.Quit();
    }

    IEnumerator fadeIn(float fadeTime, float maxAlpha = 1f)
    {
        bool faded = false;
        while(fadeTime >= 0 && !faded)
        {
            if(_fader.alpha <= maxAlpha)
                _fader.alpha += 0.001f;
            else
                faded = true;
            yield return null;
            fadeTime -= Time.deltaTime;
        }
    }

    IEnumerator fadeOut(float fadeTime, float minAlpha = 0f)
    {
        bool faded = true;
        while(fadeTime >= 0 && faded)
        {
            if(_fader.alpha >= minAlpha)
                _fader.alpha -= 0.001f;
            else
                faded = false;         
            yield return null;
            fadeTime -= Time.deltaTime;
        }
    }
}
