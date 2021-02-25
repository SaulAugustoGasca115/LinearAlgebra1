using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTestInVisionRange : MonoBehaviour
{
    public VisionRange visionRange;
    public bool seeingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(visionRange == null)
        {
            visionRange = GameObject.FindObjectOfType<VisionRange>();
        }

        seeingObject = visionRange.InVisionRange(transform.position);

        if(seeingObject)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.blue;
        }

        Gizmos.DrawSphere(transform.position,1.5f);
    }
}
