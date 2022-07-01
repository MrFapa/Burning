using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Vector2 parallaxMultiplier;

    GameObject camera;

    Vector3 oldCameraPos;
    void Start()
    {
        this.camera = Camera.main.gameObject;
    }

    
    void Update()
    {
        this.oldCameraPos = this.camera.transform.position;
    }

    private void LateUpdate()
    {
        float xDist =  this.camera.transform.position.x - this.oldCameraPos.x;
        float yDist = this.camera.transform.position.y - this.oldCameraPos.y;

        this.transform.position += new Vector3(xDist * this.parallaxMultiplier.x, yDist * this.parallaxMultiplier.y, 0);
    }
}
