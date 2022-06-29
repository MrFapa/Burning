using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] float zOffset;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = this.playerTransform.position + new Vector3(0, 0, zOffset);
    }
}
