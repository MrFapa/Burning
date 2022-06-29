using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shapes
{
    Jaguar,
    Monkey
}

public class PlayerHandler : CharacterHandler
{
    [SerializeField] protected float jaguarVelocity;
    [SerializeField] protected float monkeyVelocity;
    [SerializeField] protected float jaguarJumpForce;
    [SerializeField] protected float monkeyJumpForce;
    [SerializeField] protected float jaguarMass;
    [SerializeField] protected float monkeyMass;
    [SerializeField] protected float monkeyClimbingVelocity;
    [Range(0, 0.01f)][SerializeField] protected float jaguarJumpAgility;
    [Range(0, 0.01f)][SerializeField] protected float monkeyHorizontalAgility;

    private PlayerShapeShift playerShapeShift;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRigibody;
    private static Shapes currentForm;

    protected override void Awake()
    {
        currentForm = Shapes.Jaguar;
        
        this.playerShapeShift = this.gameObject.GetComponent<PlayerShapeShift>();
        this.playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        this.playerRigibody = this.gameObject.GetComponent<Rigidbody2D>();

        this.playerShapeShift.GetShapeShiftEvent().AddListener(ShapeShift);

        this.JaguarShift();
    }

    public static Shapes GetShape()
    {
        return currentForm;
    }

    private void ShapeShift()
    {
        if (currentForm == Shapes.Jaguar)
        {
            this.MonkeyShift();
        }
        else if (currentForm == Shapes.Monkey)
        {
            this.JaguarShift();
        }
    }

    private void JaguarShift()
    {
        currentForm = Shapes.Jaguar;
        this.playerMovement.SetVelocity(this.jaguarVelocity);
        this.playerMovement.SetJumpForce(this.jaguarJumpForce);
        this.playerMovement.SetjumpHorizontalAgility(this.jaguarJumpAgility);
        this.playerMovement.SetClimbCharacter(false);
        this.playerRigibody.mass = this.jaguarMass;
    }

    private void MonkeyShift()
    {
        currentForm = Shapes.Monkey;
        this.playerMovement.SetVelocity(this.monkeyVelocity);
        this.playerMovement.SetJumpForce(this.monkeyJumpForce);
        this.playerMovement.SetClimbVelocity(this.monkeyClimbingVelocity);
        this.playerMovement.SetjumpHorizontalAgility(this.monkeyHorizontalAgility);
        this.playerMovement.SetClimbCharacter(true);
        this.playerRigibody.mass = this.monkeyMass;
    }
}
