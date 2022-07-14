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
        if (collision.gameObject.GetComponent<IDamagable>() != null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IDamagable>().ReceiveDamage(this.damage , this.transform.position, DamageType.ENEMY);
        }
    }

    public void ReceiveDamage(int damageAmount, Vector3 pos, DamageType dmg)
    {
        this.health -= damageAmount;
        // Hiteffekt erg�nzen

        if (this.health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //Sterbe Effekt erg�nzen
        GameObject.Destroy(this.gameObject);
    }
}
