using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{

    [Header("Local References")]
    public Transform playerPosition1;
    public Transform playerPosition2;
    public Transform slopePosition1;
    public Transform slopePosition2;
    public Vector2 playerAxis;
    public Vector2 slopeAxis;

    [Header("Dot Product")]
    public float dotProduct; //producto punto
    public float cosine;

    [Header("Walking On Slope")]
    public Rigidbody2D rb;
    public float checkRadius;
    public Transform slopeCheckRight;
    public bool touchingSurfaceRight; // nos dice si esta tocando la pendiente 
    public LayerMask slopes;
    public float forceComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SlopeWalkingWithDotProduct();
    }


    void SlopeWalkingWithDotProduct()
    {
        playerAxis = playerPosition2.position - playerPosition1.position;

        slopeAxis = slopePosition2.position - slopePosition1.position;
        Debug.Log("PLAYER POS1 " + playerPosition1.position);
        Debug.Log("PLAYER POS2 " + playerPosition2.position);
        Debug.Log("PLAYER AXIS "+playerAxis);
        Debug.Log("SLOPE AXIS " + slopeAxis);

        dotProduct = Vector2.Dot(playerAxis.normalized,slopeAxis.normalized);

        Debug.Log("DOT PTODUCT " + dotProduct);

        cosine = Mathf.Acos(dotProduct);

        //Debug.Log(Mathf.Rad2Deg * cosine);

        touchingSurfaceRight = Physics2D.OverlapCircle(slopeCheckRight.position,checkRadius,slopes);


        //print("<color=red> RAIZ:" + Mathf.Sqrt(2)/2 + "</color>");

        //condicion que permite al character comntroller mover o no mover al jugador en este caso si es es coseno de 45 grados o mayor no puede caminar
        if(touchingSurfaceRight && dotProduct > (Mathf.Sqrt(2)/2))
        {
            rb.AddForce(-transform.right * forceComponent,ForceMode2D.Impulse);
            rb.AddForce(-transform.up * forceComponent, ForceMode2D.Impulse);
        }
    }


}
