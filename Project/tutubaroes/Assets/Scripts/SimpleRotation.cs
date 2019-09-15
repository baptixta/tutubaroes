using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    public bool local = true;
    public Vector3 rotation;
    public bool random = false;

    void Start ()
    {
        if (random)
        {
            rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
    }

    void Update ()
    {
        if (local)
        {
            transform.Rotate(rotation * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(rotation * Time.deltaTime, Space.World);
        }
    }
}
