using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{

    [SerializeField] private int damageAmount;


    private List<GameObject> alreadyDamagedObjects;

    void Awake()
    {
        this.alreadyDamagedObjects = new List<GameObject>();
    }

    /// <summary>
    /// Alle Objekte, die das IDamagable Interface implementiert haben erleiden Schaden und werden 
    /// danach in eine Liste gepackt, damit sie nicht mehrfach Schaden erleiden
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject objectToDamage = other.gameObject;
        IDamagable objectToDamageScript = objectToDamage.GetComponent<IDamagable>();

        if (objectToDamage != null && !this.alreadyDamagedObjects.Contains(objectToDamage))
        {
            objectToDamageScript.ReceiveDamage(damageAmount);

            this.alreadyDamagedObjects.Add(objectToDamage);
        }
    }

    public void DeactivateDamageZone()
    {
        this.gameObject.SetActive(false);
        this.alreadyDamagedObjects = new List<GameObject>();
    }
}