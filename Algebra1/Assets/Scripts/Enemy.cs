using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float distance;
    public GameObject playerObj;
    public GameObject enemyObj;
    public Rigidbody2D rb;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calcular la distancia de un objeto a otro objeto
        distance = Vector2.Distance(playerObj.transform.position,enemyObj.transform.position);

        Debug.Log("<color=green>Distance  Between Enemy and Character: "+distance+"</color>");

        if(distance < 10)
        {
            //rb.velocity = new Vector2(enemySpeed,rb.velocity.y);

            //si el enemyspeed es negativo osea -8 el enemigo nos persigue y si es posoitivo 8 el enemigo huye del character

            if(playerObj.transform.position.x < enemyObj.transform.position.x)
            {
                rb.velocity = new Vector2(enemySpeed,rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-enemySpeed, rb.velocity.y);
            }


        }


    }
}
