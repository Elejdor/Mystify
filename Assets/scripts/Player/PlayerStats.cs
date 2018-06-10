using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable<float>
{
    public float _hp = 500;
    public float _maxHP = 500;
    public bool _canRegen = true;

    void Start()
    {
        _maxHP = 500;
        _hp = _maxHP;
    }

	void Update ()
    {
        regeneration();    
    }

    public void regeneration()
    {
        if(_canRegen && (_hp < _maxHP))
        {
            Damage(-10 * Time.deltaTime);
            //Debug.Log("playerHP: " + _hp);
        }
        else if(_hp > _maxHP)
            _hp = _maxHP;
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
        yield return new WaitForSeconds(regenTime);
        _canRegen = true;
    }

}
