using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    Treead _treead;
    Vector3 InitScale;
	// Use this for initialization
	void Start () {
        GameObject treead = GameObject.Find("Treead");
        _treead = treead.gameObject.GetComponent<Treead>();
        InitScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(InitScale.x * _treead.ratio, transform.localScale.y, transform.localScale.z);
	}
}
