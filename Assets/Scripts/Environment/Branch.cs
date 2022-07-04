using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage;
    private float createdTime;

    private void Awake()
    {
        this.createdTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (createdTime + lifeTime <= Time.time)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<IDamagable>() != null)
        {
            collision.gameObject.GetComponent<IDamagable>().ReceiveDamage(this.damage, this.transform.position);
            GameObject.Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Climbable") GameObject.Destroy(this.gameObject);
    }

}
