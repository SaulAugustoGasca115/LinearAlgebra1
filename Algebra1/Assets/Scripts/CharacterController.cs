using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Rigidbody2D rb;

    [Header("Input")]
    public float walkSpeed;
    public float horizontalMovement;

    [Header("Grounded")]
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    [Header("Jump")]
    public float jumpForce;

    [Header("Sprint")]
    public float runningSpeed;

    [Header("Dash")]
    public float dashSpeed;
    public float dashTime;
    public int direction;
    public float startDashTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");      

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,ground); //codigo para saber si esta en el suelo o no esta



        WalkRun();


        Jump();

        Dash();

    }


    void WalkRun()
    {

        //Sprint Logic
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            //rb.velocity = new Vector2(runningSpeed * horizontalMovement, rb.velocity.y);

            rb.velocity = new Vector2(runningSpeed * horizontalMovement, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(walkSpeed * horizontalMovement, rb.velocity.y);
        }
    }


    void Jump()
    {
        //Jump Logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //if (Input.GetButtonDown("Jump") && !isGrounded)
            //{
            //    rb.velocity += new Vector2(rb.velocity.x, jumpForce);
            //}


        }
        else if (Input.GetButtonDown("Jump") && !isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    void Dash()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
        }
        else 
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }

        

        
    }
}
