using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [Header("Enemy 3")]
    public Rigidbody2D rb;
    public bool touchingEdgeLeft;
    public bool touchingEdgeRight;
    public float enemySpeed;
    public Transform rightCheck;
    public Transform leftCheck;
    public float checkRadius;
    public LayerMask platform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AutonomousPlatform();
    }

    void AutonomousPlatform()
    {
        touchingEdgeLeft = Physics2D.OverlapCircle(leftCheck.position, checkRadius, platform);
        touchingEdgeRight = Physics2D.OverlapCircle(rightCheck.position, checkRadius, platform);

        if(touchingEdgeLeft || touchingEdgeRight)
        {
            enemySpeed = -enemySpeed;
        }

        rb.velocity = new Vector2(enemySpeed,rb.velocity.y);
    }
}
