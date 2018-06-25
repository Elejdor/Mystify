using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour, IDamageable<float>
{
    public float _hp = 500;
    public float _maxHP = 500;
    public bool _canRegen = true;
    [SerializeField]
        ParticleSystem [] _particles;
    
    GameObject UImanager;
                 
    void Start()
    {
        _maxHP = 500;
        _hp = _maxHP;
        UImanager = GameObject.Find("TextManager");
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
        UImanager.GetComponent<UIOptions>().ChangeScene("EndScene");
    }

    public void Damage(float damage)
    {
        if(damage > 0)
            _particles[0].Play();
        else if(damage < 0)
            _particles[1].Emit(2);       
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
