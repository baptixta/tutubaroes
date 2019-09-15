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
    public float rotationFactor;
    public float maxFloatVelocity;
    public float rotationInterpolationSpeed;
    float currentRotation = 0.0f;
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
        //Rotation VERTICAL
        float desiredRotation = rb.velocity.y * rotationFactor;
        currentRotation = Mathf.Lerp(currentRotation, desiredRotation, rotationInterpolationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, currentRotation);
        //Rotation HORIZONTAL
        if (rb.velocity.x < 0) //Left
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, 180.0f, rotationInterpolationSpeed * Time.deltaTime), transform.eulerAngles.z);
        if (rb.velocity.x > 0) //Right
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, 0.0f, rotationInterpolationSpeed * Time.deltaTime), transform.eulerAngles.z);
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
            {
                rb.velocity = new Vector3(rb.velocity.x,
                                            Mathf.Clamp((floatVelocity * (-transform.position.y * pressureEffect)),
                                                            0.0f,
                                                            maxFloatVelocity),
                                            0);
            }
        }
        //Move sideways
        rb.velocity = new Vector3(moveForce * inputVector.x, rb.velocity.y, rb.velocity.z);
    }
}
