using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Declaration d'objet
    public GameObject fireBall;
    public Transform fireBallPoint;

    // Declaration d'attribut
    public float fireBallSpeed = 600;

    public void FireBallAttack()
    {
        // Ejection de la ball ou prijectile
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }
}
