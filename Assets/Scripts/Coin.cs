using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Declaration d'attribut
    public float rotateSpeed = 150f;
    

    void Update()
    {
        // Rotation de la piece
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detruire la piece lorsque le joueur entre en collision avec l'objet
        if (other.tag == "Player")
        {
            PlayerManager.numberOfCOins ++;
            Destroy(gameObject);
        }
    }
}
