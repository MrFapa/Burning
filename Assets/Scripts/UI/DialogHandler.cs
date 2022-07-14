using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject dialogFrame;
    [SerializeField] CollisionCheck trigger;
    [SerializeField] Vector3 textOffset;

    private void Start()
    {
        dialogFrame.SetActive(false);
    }

    void Update()
    {
        if (trigger.CollionsWithTag("Player"))
        {
            dialogFrame.GetComponent<RectTransform>().position = this.cam.WorldToScreenPoint(this.gameObject.GetComponent<Transform>().position + textOffset);
            dialogFrame.SetActive(true);
        }
        else
        {
            dialogFrame.SetActive(false);
        }
    }
}
