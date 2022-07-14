using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject respawn;
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IDamagable>().ReceiveDamage(this.damage, this.respawn.transform.position, DamageType.GROUND);
        }
    }
}