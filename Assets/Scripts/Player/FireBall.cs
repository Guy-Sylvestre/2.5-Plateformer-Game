using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Declaration d'objet
    public GameObject damageEffet;

    // Declaration d'attribut
    public int damageAmount = 40;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(damageEffet, transform.position, damageEffet.transform.rotation);
            other.GetComponent<Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
