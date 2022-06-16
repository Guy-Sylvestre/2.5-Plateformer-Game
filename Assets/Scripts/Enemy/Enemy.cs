using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Declaration de variable
    
    private float chaseRange = 8;
    private float speed;
    private float attackRange = 2;
    private float distance;

    // Declaration d'intance pour acceder au composant d'unity
    private Transform target;
    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        Debug.Log("----------------------###############" + distance);

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

 
}
