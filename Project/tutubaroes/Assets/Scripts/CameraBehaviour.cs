using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;
    [Header("Position")]
    public Vector3 offset;
    public float positionSpeed;
    [Range(0.0f, 1.0f)]
    public float positionInfluence = 1.0f;
    [Header("Rotation")]
    public Vector3 lookOffset;
    public float rotationSpeed;
    [Range(0.0f, 1.0f)]
    public float rotationInfluence = 1.0f;
    Transform pointer;
    [Header("Prediction")]
    public Vector3 predictionStrength;

    void Start ()
    {
        //Instanciando pointer
        pointer = new GameObject("Pointer").transform;
        pointer.SetParent(transform);
        pointer.localPosition = Vector3.zero;
        pointer.localRotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        //Interpolação entre posição da camera e posição do player (+offset)
        transform.position = Vector3.Lerp(transform.position,
                                            (player.position * positionInfluence) + offset,
                                            positionSpeed * Time.deltaTime);

        //Pointer olha pra posição do player (+lookOffset)
        pointer.LookAt((player.position * rotationInfluence) + lookOffset + new Vector3 (Input.GetAxisRaw ("Horizontal") * predictionStrength.x,
                                                                                         Input.GetAxisRaw ("Vertical") * predictionStrength.y,
                                                                                         0));
        //Interpolação entre rotação da camera e rotação do pointer
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                            pointer.rotation,
                                            rotationSpeed * Time.deltaTime);
    }
}
