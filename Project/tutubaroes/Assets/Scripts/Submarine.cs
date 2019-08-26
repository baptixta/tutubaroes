using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Submarine : MonoBehaviour
{
    public float waterLevel;
    public float floatVelocity;
    public float diveVelocity;
    public float moveForce;
    public float pressureEffect;
    Vector3 inputVector;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Getting input
        inputVector = new Vector3(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
    }

    void FixedUpdate()
    {
        //Dive
        if (inputVector.y < 0 && transform.position.y <= waterLevel)
        {
            rb.velocity = new Vector3(rb.velocity.x, diveVelocity * inputVector.y, 0);
        }
        else if (transform.position.y < 0) //Float
        {
            if (transform.position.y <= waterLevel - 0.2f)
                rb.velocity = new Vector3(rb.velocity.x, floatVelocity * (-transform.position.y * pressureEffect), 0);
        }

        //Move sideways
        rb.velocity = new Vector3(moveForce * inputVector.x, rb.velocity.y, rb.velocity.z);
    }
}
