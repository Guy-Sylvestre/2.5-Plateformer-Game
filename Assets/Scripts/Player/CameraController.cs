using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Declaration d'intance pour acceder au composant d'unity
    private Transform target;
    private Vector3 offset;

    // Declaration de variable
    public float smoothSpeed = 0.15f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

   
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}