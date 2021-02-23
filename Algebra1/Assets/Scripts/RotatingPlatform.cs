using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [Header("Local References")]
    public Transform playerPosition1;
    public Transform playerPosition2;
    public Transform platformPosition1;
    public Transform platformPosition2;
    public Vector2 playerAxis;
    public Vector2 platformAxis;

    [Header("Dot Product")]
    public float dotProduct;

    [Header("Rotation")]
    public float rotationRate = 45f;
    public float angle;
    public float limit = Mathf.Sqrt(2) / 2;
    private BoxCollider2D platformBox;

    // Start is called before the first frame update
    void Start()
    {
        platformBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAxis = playerPosition2.position - playerPosition1.position;
        platformAxis = platformPosition2.position - platformPosition1.position;

        dotProduct = Vector2.Dot(playerAxis.normalized, platformAxis.normalized);

        transform.Rotate(0,0,rotationRate * Time.deltaTime);

        if((dotProduct < limit) && (dotProduct > -limit))
        {
            platformBox.enabled = true;
        }
        else
        {
            platformBox.enabled = false;
        }
    }
}
