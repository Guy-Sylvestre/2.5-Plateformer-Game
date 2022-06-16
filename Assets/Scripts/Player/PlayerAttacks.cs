using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Declaration d'intance pour acceder au composant d'unity
    public GameObject fireBall;
    public Transform fireBallPoint;

    // Declaration de variable
    public float fireBallSpeed = 600;

    public void FireBallAttack()
    {
        // Ejection de la ball ou prijectile
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }
}
