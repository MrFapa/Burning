using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType{
    ENEMY,
    GROUND,
    FALLINGOBJ
}  

public interface IDamagable
{
    int Health { get; }

    void ReceiveDamage(int damageAmount, Vector3 position, DamageType type);
}
