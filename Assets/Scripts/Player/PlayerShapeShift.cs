using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerShapeShift : MonoBehaviour
{
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
    }
}
