using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("Objekt für die Hitbox, dem Spieler untergeorndet")]
    [SerializeField] private CollisionCheck attackZone;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDuration;
    [SerializeField] private int damageAmount;

    private List<GameObject> collisions;
    private List<GameObject> alreadyChecked;

    bool attacking = false;
    float timeUntilNextAttack;

    void Start()
    {
        this.timeUntilNextAttack = Time.time;
        this.collisions = new List<GameObject>();
        this.alreadyChecked = new List<GameObject>();
    }

    void FixedUpdate()
    {
        if (attacking)
        {
            GameObject[] tmp = collisions.ToArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].GetComponent<IDamagable>() != null && !this.alreadyChecked.Contains(tmp[i]))
                {
                    tmp[i].GetComponent<IDamagable>().ReceiveDamage(damageAmount);
                }
                this.alreadyChecked.Add(tmp[i]);
            }
            collisions.Clear();
        }
    }

    /// <summary>
    /// Aktiviert die Hitbox, welche über einen Trigger andere Objekte damaged.
    /// Nachdem der Angriff vorbei ist wird die Hitbox reseted und wieder deaktiviert.
    /// </summary>
    public IEnumerator Attack()
    {
        if (this.CanAttack() && PlayerHandler.GetShape() == Shapes.Jaguar)
        {
            //Neuer Cooldown
            this.timeUntilNextAttack = Time.time + this.attackCooldown;

            //Setzt alles notwendige auf
            this.attacking = true;
            this.attackZone.SetActive(true);
            this.attackZone.GetNewCollisionEvent().AddListener(this.RefreshList);
            this.collisions = this.attackZone.GetCollisions();

            //Pausiert während der Attacke
            yield return new WaitForSeconds(this.attackDuration);

            //Beendet die Attacke
            this.attackZone.SetActive(false);
            this.alreadyChecked.Clear();
            this.attacking = false;
        }  
    }

    private bool CanAttack()
    {
        return Time.time >= this.timeUntilNextAttack;
    }

    private void RefreshList()
    {
        this.collisions = this.attackZone.GetCollisions();
    }
}
