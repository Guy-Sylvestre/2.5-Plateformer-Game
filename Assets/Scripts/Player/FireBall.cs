using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Declaration d'intance pour acceder au composant d'unity
    public GameObject damageEffet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(damageEffet, transform.position, damageEffet.transform.rotation);
            Destroy(gameObject);
        }
    }
}
