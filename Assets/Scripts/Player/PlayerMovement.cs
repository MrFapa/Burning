using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private void Update()
    {
        Move();
    }

    public override void SetMovement(float pHorizontalInput, float pVerticalInput, bool pJumpInput)
    {
        this.horizontalMovement = pHorizontalInput;
        this.verticalMovement = pVerticalInput;
        this.jump = pJumpInput;
    }

    public override void Move()
    {
        if (this.IsGrounded())
        {
            this.SetClimbing(false);
            this.mRigidbody.velocity = new Vector2(this.horizontalMovement * this.velocity, this.mRigidbody.velocity.y);

            if (this.jump)
            {
                this.mRigidbody.velocity = new Vector2(this.mRigidbody.velocity.x, 0);
                this.mRigidbody.AddForce(new Vector2(0, this.jumpForce));
                this.jump = false;
            }
            else if (this.CanClimb() && this.horizontalMovement != 0)
            {
                this.SetClimbing(true);
            }
        }
        if (this.IsClimbing())
        {
            if (this.CanClimb())
            {
                this.mRigidbody.velocity = new Vector2(this.mRigidbody.velocity.x, this.verticalMovement * this.climbingVelocity);
                if (this.jump && this.horizontalMovement !=0 )
                {
                    this.SetClimbing(false);
                    this.mRigidbody.velocity = new Vector2(this.velocity * 0.5f * this.horizontalMovement, 0);
                    this.mRigidbody.AddForce(new Vector2(0, this.jumpForce * 0.5f));
                    this.jump = false;

                }
            }else
            {
                this.SetClimbing(false);
            }
        }if (this.IsInAir())
        {
            this.SetClimbing(false);
            this.mRigidbody.velocity = new Vector2(Mathf.Clamp(this.mRigidbody.velocity.x + this.jumpHorizontalAgility * (this.velocity * this.horizontalMovement), this.velocity * -1, this.velocity), this.mRigidbody.velocity.y);
            if (this.CanClimb() && this.horizontalMovement != 0)
            {
                this.SetClimbing(true);
            }
        }
    }
}