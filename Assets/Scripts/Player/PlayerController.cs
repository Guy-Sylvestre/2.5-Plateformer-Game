using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 direction;
    public float speed;
    public float jumpForce = 10f;
    public float gravity = -20f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool ableToMakeADoubleJump = true;
    public Animator animator;
    public Transform model;
    void Start()
    {
        
    }

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        // Declancher l'animation
        float convertAbsolueValue = Mathf.Abs(hInput);
        animator.SetFloat("Speed", convertAbsolueValue);

        bool isGround = Physics.CheckSphere(groundCheck.position, 0.2f,groundLayer);
        animator.SetBool("isGrounded", isGround);

        if (isGround)
        {
            direction.y += -1;
            ableToMakeADoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }else
        {
            direction.y += gravity * Time.deltaTime;
            if (ableToMakeADoubleJump && Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("doubleJump");
                direction.y = jumpForce;
                ableToMakeADoubleJump = false;
            }
        }

        // Fliper la direction du personnage
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0f, 0f));
            model.rotation = newRotation;
        }

        controller.Move(direction * Time.deltaTime);
    }
}
