using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golire : MonoBehaviour, IDamageable<int>
{
    [SerializeField]
    GameObject _golire;
                         
    private int _hp;
            
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void death()
    {
        Destroy(_golire);
    }

    public void Damage(int damage)
    {
        Debug.Log("HP: " + _hp);
        _hp -= damage;
        if(_hp <= 0)
            death();
    }

}
