using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private int damage;

    public int Health
    {
        get { return health; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            collision.gameObject.GetComponent<IDamagable>().ReceiveDamage(this.damage);
        }
    }

    public void ReceiveDamage(int damageAmount)
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
