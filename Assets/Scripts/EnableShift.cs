using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableShift : MonoBehaviour
{
    [SerializeField] PlayerHandler player;
    [SerializeField] CollisionCheck trigger;
    [SerializeField] bool jaguar;
    [SerializeField] bool monkey;

    private void Start()
    {
        trigger.GetNewCollisionEvent().AddListener(this.Enable);
    }

    private void Enable()
    {
        if (this.jaguar)
        {
            this.player.EnableJaguar();
        }
        if (this.monkey)
        {
            this.player.EnableMonkey();
        }
    }
}
