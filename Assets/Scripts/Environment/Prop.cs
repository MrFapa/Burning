using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
    }

    public void ReceiveDamage(int damageAmount, Vector3 pos, DamageType dmg)
    {
        this.health -= damageAmount;
        // Hiteffekt ergänzen

        if (this.health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //Sterbe Effekt ergänzen
        GameObject.Destroy(this.gameObject);
    }
}
