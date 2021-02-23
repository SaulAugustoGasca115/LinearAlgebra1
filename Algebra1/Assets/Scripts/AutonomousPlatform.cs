using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousPlatform : MonoBehaviour
{

    [Header("Platform")]
    public float platformSpeed;
    public Transform rightLimit;
    public Transform leftLimit;
    public Transform upLimit;
    public Transform downLimit;
    public Transform checkPosition;
    public float tolarence = 1.0f;
    public bool OtherBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!OtherBehaviour)
        {
            MoveRightToLeft();
        }
        else
        {
            MoveUpDown();
        }

    }

    void MoveRightToLeft()
    {
      if((transform.position.x < rightLimit.position.x + tolarence && transform.position.x > rightLimit.position.x - tolarence) || (transform.position.x < leftLimit.position.x + tolarence && transform.position.x > leftLimit.position.x - tolarence))
      {
            platformSpeed = -platformSpeed;
            Debug.Log("Arrived");

      }

        transform.Translate(platformSpeed * Time.deltaTime,0,0);
    }

    void MoveUpDown()
    {
        if((transform.position.y < upLimit.position.y + tolarence && transform.position.y > upLimit.position.y - tolarence) || (transform.position.y < downLimit.position.y + tolarence && transform.position.y > downLimit.position.y -tolarence))
        {
            platformSpeed = -platformSpeed;
        }


        transform.Translate(0, platformSpeed * Time.deltaTime, 0);
    }
}
