using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask bounceMask;  

    private Vector3 currentDirection;

    void Start()
    {
        currentDirection = transform.parent.forward;
    }

    void Update()
    {
        Vector3 newPosition = transform.position + currentDirection * speed * Time.deltaTime;

        if (Physics.Linecast(transform.position, newPosition, out RaycastHit hit, bounceMask))
        {
            currentDirection = Vector3.Reflect(currentDirection, hit.normal);
        }

        transform.position = newPosition;
    }
}
