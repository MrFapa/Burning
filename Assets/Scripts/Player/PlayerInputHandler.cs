using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerShapeShift playerShapeShift;
    private PlayerAttack playerAttack;

    private float playerIHorizantal;
    private float playerIVertical;
    private bool playerIJump;
    private bool playerIShapeShift;
    private bool playerIAttack;

    private void Awake()
    {
        this.playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        this.playerShapeShift = this.gameObject.GetComponent<PlayerShapeShift>();
        this.playerAttack = this.gameObject.GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        //Get user inputs

        //Horizontal
        this.playerIHorizantal = Input.GetAxisRaw("Horizontal");
        this.playerIVertical = Input.GetAxisRaw("Vertical");

        //Jumping 
        checkButtonPress("Jump", ref this.playerIJump);

        //ShapeShift
        checkButtonPress("Shape Shift", ref this.playerIShapeShift);

        //Attack
        checkButtonPress("Fire1", ref this.playerIAttack);

    }

    private void FixedUpdate()
    {   
        //Übergibt die Inputs an Playermovement
        this.playerMovement.SetMovement(this.playerIHorizantal, this.playerIVertical, this.playerIJump);
        this.playerIJump = false;

        //Übergibt die Inputs an PlayerShapeShift
        if (this.playerIShapeShift)
        {
            this.playerShapeShift.Shift();
            this.playerIShapeShift = false;
        }

        //Übergibt die Inputs an PlayerAttack
        if (this.playerIAttack)
        {
            StartCoroutine(this.playerAttack.Attack());
            this.playerIAttack = false;
        }
    }

    private void checkButtonPress(string buttonName, ref bool trigger)
    {
        if (Input.GetButtonDown(buttonName))
        {
            trigger = true;
        }
    }
}