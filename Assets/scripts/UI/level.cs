using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void ChangeScene2(string sceneName)
    {
        //m_instance.StartCoroutine(m_instance.fadeOut(5));
        SceneManager.LoadScene(sceneName);
        //m_instance.StartCoroutine(m_instance.fadeIn(5));       
    }
}
