using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = transform.forward * speed;
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
            //Bounce
            Vector3 normal = other.ClosestPoint(transform.position) - transform.position;
            normal.Normalize();
            transform.forward = Vector3.Reflect(transform.forward, normal);
        }
    }
}
