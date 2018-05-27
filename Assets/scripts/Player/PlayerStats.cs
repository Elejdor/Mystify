using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable<float>
{
    private float _hp = 200;
    private float _maxHP = 200;
    public bool _canRegen = true;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        regeneration();

    }

    public void regeneration()
    {
        if(_canRegen && (_hp < _maxHP))
        {
            Damage(-2 * Time.deltaTime);
            //Debug.Log("playerHP: " + _hp);
        }
        else
            StartCoroutine(RegenerationTime());
    }   

    public void death()
    {
        Time.timeScale = 0f;
    }

    public void Damage(float damage)
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
