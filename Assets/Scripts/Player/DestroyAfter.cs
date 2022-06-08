using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    // Declaration de variable
    public float lifeDuration;
    
    void Start()
    {
        Destroy(gameObject, lifeDuration);
    }
}
