using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator animator;
    private PlayerMovement movementScript;

    bool isRunning = false;

    void Awake()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.movementScript = this.gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!this.movementScript.IsClimbing())
        {
            float movement = this.movementScript.GetHorizontal();
            this.isRunning = (movement != 0) ? true : false;
            this.animator.SetBool("isRunning", this.isRunning);


            int lookDirection = (int)movement;
            if (lookDirection == 0) return;
            this.gameObject.transform.localScale = new Vector3(lookDirection, 1, 0);
        }
        else
        {
            this.animator.SetBool("isRunning", false);
        }
    }

    public void setShape(int shape)
    {
        this.animator.SetInteger("Shape", shape);
    }
}