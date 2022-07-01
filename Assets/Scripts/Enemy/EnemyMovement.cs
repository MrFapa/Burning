using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] protected CollisionCheck checkGround0;

    private float dircetion;
    private Rigidbody2D mRigidbody;

    private void Awake()
    {
        this.mRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        this.dircetion = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.checkGround0.CollionsWithTag("Ground"))
        {
            this.dircetion *= -1;
        }
        mRigidbody.velocity = this.mRigidbody.velocity = new Vector2(this.dircetion * this.velocity, this.mRigidbody.velocity.y);
        this.gameObject.transform.localScale = new Vector3(dircetion * -1, 1, 0);
    }
}
