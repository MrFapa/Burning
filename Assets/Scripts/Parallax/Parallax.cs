using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Vector2 parallaxMultiplier;

    [SerializeField] GameObject camera;

    Vector3 oldCameraPos;

    float textureUnitSize;

    private void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        this.textureUnitSize = texture.width / sprite.pixelsPerUnit;
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


        if(this.camera.transform.position.x - this.transform.position.x >= this.textureUnitSize)
        {
            float offsetPosition = (this.camera.transform.position.x - this.transform.position.x) % this.textureUnitSize;
            this.transform.position = new Vector3(this.camera.transform.position.x + offsetPosition, this.transform.position.y);
        }

    }
}
