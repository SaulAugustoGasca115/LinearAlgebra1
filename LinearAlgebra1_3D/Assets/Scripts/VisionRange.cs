using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRange : MonoBehaviour
{

    public Vector3 referenceToObjects;
    public float dotProduct;
    public float visionBorder = 45f; //limite del cono (rango de vision)
    public float angle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool InVisionRange(Vector3 inputPoint)
    {
        referenceToObjects = inputPoint - transform.position;

        dotProduct = Vector3.Dot(referenceToObjects.normalized, transform.forward);

        angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        return angle < visionBorder;

        Debug.Log("<color=red> IN VISON RANGE </color>");
    }

}
