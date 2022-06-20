using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaration d'intance pour acceder au composant d'unity
    public CharacterController controller;
    public Vector3 direction;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform model;

    // Declaration de variable
    public float speed;
    public float jumpForce = 10f;
    public bool ableToMakeADoubleJump = true;
    public float gravity = -20f;
    

    void Update()
    {
        if (PlayerManager.gameOver)
        {
            // Play death animation
            animator.SetTrigger("die");

            // Disable the script
            this.enabled = false;
        }

        // Recuperation de la saisie horizontal (Gauche, droite)
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        // Declancher l'animation
        float convertAbsolueValue = Mathf.Abs(hInput);
        animator.SetFloat("Speed", convertAbsolueValue);

        // Verifier si le joueur est au sol
        bool isGround = Physics.CheckSphere(groundCheck.position, 0.2f,groundLayer);
        animator.SetBool("isGrounded", isGround);

        if (isGround)
        {
            direction.y += -1;
            ableToMakeADoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                // Simple Jump
                SimpleJump();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("fireBallAttack");
            }
        }else
        {
            direction.y += gravity * Time.deltaTime; //Add Gravity
            if (ableToMakeADoubleJump && Input.GetButtonDown("Jump"))
            {
                // Double Jump
                DoubleJump();
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball"))
        {
            return;
        }

        // Fliper la direction du personnage
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0f, 0f));
            model.rotation = newRotation;
        }

        // Move the player using the charactere controller
        controller.Move(direction * Time.deltaTime);

        // Frizer l'axe z
        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }


    private void DoubleJump()
    {
        // Double Jump
        animator.SetTrigger("doubleJump");
        direction.y = jumpForce;
        ableToMakeADoubleJump = false;
    }

    private void SimpleJump()
    {
        // Simple Jump
        direction.y = jumpForce;
    }
}
