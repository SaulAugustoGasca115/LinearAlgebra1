using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntuition : MonoBehaviour
{
    [Header("Cross Product")]
    public static RotationAxis rotationAxisClass;
    public Vector3 rotationAxis;
    public float angle;

    [Header("Trigger Intuition")]
    public float distance;
    public GameObject player;
    public GameObject enemy;
    public Vector3 nose;
    public float rotationSpeed = 7.0f;


    [Header("ERnemy Walking")]
    public Rigidbody rb;
    public Vector3 direction2Player;
    public float forceComponent = 25.0f;


    // Start is called before the first frame update
    void Start()
    {
        if (rotationAxisClass == null)
        {
            rotationAxisClass = GameObject.FindObjectOfType<RotationAxis>();
        }

        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {

        direction2Player = player.transform.position - transform.position;

        distance = Vector3.Distance(player.transform.position,enemy.transform.position);

        if(distance < 20)
        {
            rotationAxis = rotationAxisClass.DetermineRotationAxis(transform.position, transform.forward);
            angle = rotationAxisClass.DetermineAngle(transform.position, transform.forward);

            rotationAxis = new Vector3(0,rotationAxis.y,0);

            transform.Rotate(rotationAxis,angle * Time.deltaTime * rotationSpeed);

            if(distance < 10)
            {
                rb.AddForce(direction2Player.normalized * forceComponent);
            }
        }

        

        nose = transform.forward;
    }
}
