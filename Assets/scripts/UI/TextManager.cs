using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TextStates
{
    NoText,
    Epilogue,
    Game1,
    Game2,
    Game3,
    Anger1,
    Anger2,
    Anger3,
    Ending1,
    Ending2,
    Ending3,
    GameOver,
}

public class TextManager : MonoBehaviour
{                      

    [SerializeField]
        Text text;

    public TextStates currentState;
    private static bool created = false;

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
        text.text = "";
        currentState = TextStates.NoText;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(currentState == TextStates.NoText)
        {    
            text.text = "";
        }
        else if(currentState == TextStates.Epilogue)
        {
            text.text = "Anger devours you...";
        }
        else if(currentState == TextStates.GameOver)
        {
            text.text = "Too late...";
        }
	}
}
