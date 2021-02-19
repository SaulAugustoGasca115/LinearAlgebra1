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


        WalkRun(); //Esta funcion contiene la logica para que el personaje Camine o Corra


        Jump(); // Esta funcion contiene la logica para que el personaje Brinque en el aire indefinidamente

        Dash(); //Esta funcion contiene la logica para craer una embestida

    }


    void WalkRun()
    {

        //Sprint Logic 
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            

            rb.velocity = new Vector2(runningSpeed * horizontalMovement, rb.velocity.y); // esta linea de codigo funciona para que el personaje corra
        }
        else
        {
            rb.velocity = new Vector2(walkSpeed * horizontalMovement, rb.velocity.y); //esta linea de codigo funciona paraq ue el personaje camine
        }
    }


    void Jump()
    {
        //Jump Logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //esta linea de codigo permite brincar una vez estando en el suelo

          
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // esta linea de codigo permite brincar indefinidamente en el airte

        }
    }

    void Dash()
    {
        //logica de embestida
        if (direction == 0) //la direccion del peronaje es 0, es decir , que aun no hay una direccion a la cual embestir
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1; //si el jugadoir persona la tecla fechja izquierda la direccion es 1
            }else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2; //si el jugadoir persona la tecla tecla derecha la direccion es 2 
            }
        }
        else 
        {
            if (dashTime <= 0) // si el tiempo de embestida es igual o menor a 0 la direccion, el tiempo y la velocidad de la fisica permanece en 0.
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else // si el tiempo de embvestida es por lo menos 1 , tomara una direccion , ya sea a la izquierda o derecha
            {
                dashTime -= Time.deltaTime; // se resta el tiempo de cada frame en cada emebestida realziada, se considera buena practica

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed; //si la direccion es 1 el character se embestira  hacia la izquierda con la velocidad proporcionada
                }else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed; //si la direccion es 1 el character se embestira  hacia la derecha con la velocidad proporcionada
                }
            }
        }

        

        
    }
}
