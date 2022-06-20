using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Declaration d'attribut
    
    private float chaseRange = 10;
    private float speed;
    private float attackRange = 2;
    private float distance;
    public int health;
    public int maxHealth;

    // Declaration d'intance pour acceder au composant d'unity
    private Transform target;
    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    void Update()
    {

        if (PlayerManager.gameOver)
        {
            // Stop the animation of the enemy when the player dies
            animator.enabled = false;
            this.enabled = false;
        }

        distance = Vector3.Distance(transform.position, target.position);
        // Debug.Log("----------------------###############" + distance);

       if (distance < chaseRange)
        {
            // Play the run animation
            animator.SetBool("runingEnemy", true);
            animator.SetBool("attackEnemy", false);
            speed = 3;

            if (distance < attackRange)
            {
                animator.SetBool("attackEnemy", true);
                speed = 0;
            }

            // Move towards the player
            MouvementEnemy();
            
        }else if (distance < attackRange)
        {
            animator.SetBool("attackEnemy", true);
            speed = 0;

            if (distance > attackRange)
            {
                animator.SetBool("runingEnemy", true);
                animator.SetBool("attackEnemy", false);
                speed = 3;
                MouvementEnemy();

            }
        }else
        {
            speed = 0;
            animator.SetBool("attackEnemy", false);
            animator.SetBool("runingEnemy", false);
        }
    }

    private void MouvementEnemy()
    {
        if (target.position.x > transform.position.x)
            {
                // Move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // Move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health < 0)
        {
            Die();
        }
    }


    public void Die()
    {
        // Play a die animation
        animator.SetTrigger("isDead");

        // disable the script and the collider
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }

 
}
