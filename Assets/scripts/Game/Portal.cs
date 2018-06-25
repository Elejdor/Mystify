using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{                     
        GameObject UImanager;

    public void Start()
    {        
        UImanager = GameObject.Find("TextManager");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
            UImanager.GetComponent<UIOptions>().ChangeScene("Anger");
    }
}
