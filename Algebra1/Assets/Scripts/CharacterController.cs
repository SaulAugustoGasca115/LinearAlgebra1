using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Rigidbody2D rb;

    [Header("Input")]
    public float walkSpeed;
    public float horizontalMovement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(walkSpeed * horizontalMovement, rb.velocity.y);
    }
}
