using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Shapes
{
    Jaguar,
    Monkey
}

public class PlayerHandler : MonoBehaviour, IDamagable
{
    [SerializeField] protected float jaguarVelocity;
    [SerializeField] protected float monkeyVelocity;
    [SerializeField] protected float jaguarJumpForce;
    [SerializeField] protected float monkeyJumpForce;
    [SerializeField] protected float jaguarMass;
    [SerializeField] protected float monkeyMass;
    [SerializeField] protected float monkeyClimbingVelocity;
    [SerializeField] protected GameObject[] hearths;

    [Range(0, 0.01f)][SerializeField] protected float jaguarJumpAgility;
    [Range(0, 0.01f)][SerializeField] protected float monkeyHorizontalAgility;

    private PlayerShapeShift playerShapeShift;
    private PlayerMovement playerMovement;
    private PlayerAnimationController playerAnimation;
    private Rigidbody2D playerRigibody;
    private static Shapes currentForm;

    private static bool monkeyShape;
    private static bool jaguarShape;

    private float lastHit;

    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
    }


    private void Start()
    {
        monkeyShape = true;
        jaguarShape = false;

        this.playerShapeShift = this.gameObject.GetComponent<PlayerShapeShift>();
        this.playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        this.playerRigibody = this.gameObject.GetComponent<Rigidbody2D>();
        this.playerAnimation = this.gameObject.GetComponent<PlayerAnimationController>();
        this.playerShapeShift.GetShapeShiftEvent().AddListener(ShapeShift);

        this.lastHit = Time.time;

        this.MonkeyShift();
    }

    public static Shapes GetShape()
    {
        return currentForm;
    }

    public void ReceiveDamage(int damageAmount, Vector3 pos, DamageType dmg)
    {
        if (Time.time >= this.lastHit + 1f)
        {
            lastHit = Time.time;
            this.health -= damageAmount;

            
            switch (dmg)
            {
                case DamageType.ENEMY:
                    {
                        int direction = (this.GetComponent<Transform>().position.x < pos.x) ? -1 : 1;
                        this.playerRigibody.AddForce(new Vector2(direction * 400, 400));
                        break;
                    }
                case DamageType.FALLINGOBJ:
                    {
                        int direction = (this.GetComponent<Transform>().position.x < pos.x) ? -1 : 1;
                        this.playerRigibody.AddForce(new Vector2(direction * 100, -100));
                        break;
                    }
                case DamageType.GROUND:
                    {
                        this.playerRigibody.velocity = new Vector3(0, 0, 0);
                        this.transform.position = pos; 
                        break;
                    }
            }
            

            this.hearths[this.health].SetActive(false);

            if (this.health <= 0)
            {
                Die();
            }
        }
    }

    public void EnableJaguar()
    {
        jaguarShape = true;
    }

    public void EnableMonkey()
    {
        monkeyShape = true;
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
        if (jaguarShape)
        {
            currentForm = Shapes.Jaguar;
            this.playerAnimation.setShape(0);
            this.playerMovement.SetVelocity(this.jaguarVelocity);
            this.playerMovement.SetJumpForce(this.jaguarJumpForce);
            this.playerMovement.SetjumpHorizontalAgility(this.jaguarJumpAgility);
            this.playerMovement.SetClimbCharacter(false);
            this.playerRigibody.mass = this.jaguarMass;
        }
    }

    private void MonkeyShift()
    {
        if (monkeyShape)
        {
            currentForm = Shapes.Monkey;
            this.playerAnimation.setShape(1);
            this.playerMovement.SetVelocity(this.monkeyVelocity);
            this.playerMovement.SetJumpForce(this.monkeyJumpForce);
            this.playerMovement.SetClimbVelocity(this.monkeyClimbingVelocity);
            this.playerMovement.SetjumpHorizontalAgility(this.monkeyHorizontalAgility);
            this.playerMovement.SetClimbCharacter(true);
            this.playerRigibody.mass = this.monkeyMass;
        }   
    }

    private void Die()
    {
        //Sterbe Effekt ergänzen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
