using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable<int>
{
    private int _hp = 200;
    private int _maxHP = 200;
    public bool _canRegen = true;

	// Use this for initialization
	void Start ()
    {
        regeneration();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void regeneration()
    {
        if(_canRegen && (_hp <= _maxHP) )
        {
            Damage(-1);
        }
    }   

    public void death()
    {
        Time.timeScale = 0f;
    }

    public void Damage(int damage)
    {
        Debug.Log("player HP: " + _hp);
        _hp -= damage;
        if(_hp <= 0)
            death();
    }

    public IEnumerator RegenerationTime()
    {
        float regenTime = 5f;
        while(regenTime > 0f)
        {
            yield return null;
            regenTime -= Time.deltaTime;
        }
        _canRegen = true;
    }

}
