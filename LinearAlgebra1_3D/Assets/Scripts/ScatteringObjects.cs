using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatteringObjects : MonoBehaviour
{
    public int numberOfObjects;
    public float radius = 50f;
    //public GameObject[] numberOfObjets;
    //public GameObject scatterObject;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfObjects; i++)
        {
            GameObject so = new GameObject();
            so.transform.position = Random.insideUnitSphere * radius;
            so.AddComponent(typeof(ObjectTestInVisionRange));
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void CloneObjectToRangeVision()
    //{
    //    for(int i = 0;i < numberOfObjets.Length;i++)
    //    {
    //        GameObject so = Instantiate(scatterObject) as GameObject;
    //        so.transform.position = Random.insideUnitSphere * radius;
    //        so.AddComponent(typeof(ObjectTestInVisionRange));
    //    }
    //}
}
