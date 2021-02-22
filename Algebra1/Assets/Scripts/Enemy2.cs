using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public Rigidbody2D rb;
    public float enemySpeed;
    public bool touchingEdgeRight;
    public bool touchingEdgeLeft;
    public Transform rightCheck;
    public Transform leftCheck;
    public float checkRadius;
    public LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //touchingEdgeLeft = Physics2D.OverlapCircle(leftCheck.position, checkRadius, ground);
        //touchingEdgeRight = Physics2D.OverlapCircle(rightCheck.position, checkRadius, ground);


        //if (touchingEdgeRight || touchingEdgeLeft)
        //{
        //    enemySpeed = -enemySpeed;

        //}

        //rb.velocity = new Vector2(enemySpeed, rb.velocity.y);

        AutonomousMovement();
    }

    Vector2 AutonomousMovement()
    {
        touchingEdgeLeft = Physics2D.OverlapCircle(leftCheck.position, checkRadius, ground);
        touchingEdgeRight = Physics2D.OverlapCircle(rightCheck.position, checkRadius, ground);

        if(touchingEdgeLeft || touchingEdgeRight)
        {
            enemySpeed = -enemySpeed;
        }

         rb.velocity = new Vector2(enemySpeed, rb.velocity.y);

        return rb.velocity;
    }
}
