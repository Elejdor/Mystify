using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyTypes
{
    Treead,
    Breeze,
    Golire
}  

public interface IDamageable<T>
{
    void Damage(T damage);
}
 
