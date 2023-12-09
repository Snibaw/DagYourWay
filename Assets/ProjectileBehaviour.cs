using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 10f;
    
    void FixedUpdate()
    {
        transform.position += transform.forward * (speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered projectile with " + other.name);
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            // Bounce
            Vector3 normal = other.ClosestPoint(transform.position) - transform.position;
            normal.Normalize();
            Vector3 forward = Vector3.Reflect(transform.forward, normal);
            transform.forward = new Vector3(forward.x, forward.y, 0).normalized;
        }
    }
}
