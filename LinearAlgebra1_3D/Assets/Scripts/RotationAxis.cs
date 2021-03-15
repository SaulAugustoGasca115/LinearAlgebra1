using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAxis : MonoBehaviour
{
    [Header("Player Attributes")]
    public Vector3 nose;

    [Header("CrossProduct")]
    public Vector3 reference2Objects;
    public Vector3 rotationAxis;


    [Header("Dot Product")]
    public float dotProduct;
    public float angle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nose = transform.forward;
    }

    public Vector3 DetermineRotationAxis(Vector3 input,Vector3 enemyDirection)
    {

        reference2Objects = -(input - transform.position);
        rotationAxis = Vector3.Cross(enemyDirection,reference2Objects.normalized);

        return rotationAxis;
    }

    public float DetermineAngle(Vector3 input,Vector3 enemyDirection)
    {
        reference2Objects = -(input - transform.position);
        dotProduct = Vector3.Dot(enemyDirection, reference2Objects.normalized);

        angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        return angle;
    }

}
