using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected CollisionCheck checkClimb;
    [SerializeField] protected CollisionCheck checkGround;

    protected Rigidbody2D mRigidbody;
    protected Transform mTransform;
    protected GameObject groundCheck;

    protected bool climbCharacter;
    protected float velocity;
    protected float climbingVelocity;
    protected float jumpForce;
    protected float jumpHorizontalAgility;

    protected float verticalMovement;
    protected float horizontalMovement;
    protected bool jump;

    private bool isClimbing;

    public abstract void SetMovement(float pHorizontal, float pVerticalMovement, bool pJump);

    public abstract void Move();

    protected void Awake()
    {
        this.mRigidbody = this.gameObject.GetComponent<Rigidbody2D>();   
        this.mTransform = this.gameObject.GetComponent<Transform>();
    }

    public bool IsClimbing()
    {
        return this.isClimbing;
    }

    public void SetClimbCharacter(bool pClimb)
    {
        this.climbCharacter = pClimb;
    }

    public void SetVelocity(float pVel)
    {
        this.velocity = pVel;
    }

    public void SetJumpForce(float pForce)
    {
        this.jumpForce = pForce;
    }

    public void SetClimbVelocity(float pClimbVel)
    {
        this.climbingVelocity = pClimbVel;
    }

    public void SetjumpHorizontalAgility(float pAgility)
    {
        this.jumpHorizontalAgility = pAgility;
    }

    public float GetHorizontal()
    {
        return this.horizontalMovement;
    }

    public bool IsGrounded()
    {
        return this.checkGround.CollionsWithTag("Ground");
    }

    public bool IsInAir()
    {
        return !this.isClimbing && !this.IsGrounded();
    }

    protected void SetClimbing(bool pClimb)
    {
        this.isClimbing = pClimb;
        this.mRigidbody.gravityScale = (pClimb) ? 0 : 1;
    }

    protected bool CanClimb()
    {
        return this.checkClimb.CollionsWithTag("Climbable") && this.climbCharacter;
    }
}