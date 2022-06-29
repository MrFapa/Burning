using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerShapeShift : MonoBehaviour
{
    private bool shape = true;
    private UnityEvent shapeShiftEvent;

    private void Awake()
    {
        this.shapeShiftEvent = new UnityEvent();
    }

    public UnityEvent GetShapeShiftEvent()
    {
        return this.shapeShiftEvent;
    }

    public void Shift()
    {
        this.shapeShiftEvent.Invoke();
        //this is just a placeholder for the real shape shift
        if (shape)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        shape = !shape;
    }
}
