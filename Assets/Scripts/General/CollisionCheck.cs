using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCheck : MonoBehaviour
{
    private List<GameObject> collisions;
    private UnityEvent newCollisionEvent;

    private void Awake()
    {
        newCollisionEvent = new UnityEvent();
        collisions = new List<GameObject>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions.Add(collision.gameObject);
        this.newCollisionEvent.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisions.Remove(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisions.Add(collision.gameObject);
        this.newCollisionEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisions.Remove(collision.gameObject);
    }

    public void SetActive(bool b)
    {
        this.gameObject.SetActive(b);
    }

    public UnityEvent GetNewCollisionEvent()
    {
        return this.newCollisionEvent;
    }

    public List<GameObject> GetCollisions()
    {
        return this.collisions;
    }

    public bool CollionsWithTag(string tag)
    {
        foreach (GameObject n in collisions)
        {
            if (n.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
