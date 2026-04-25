using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassIf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x >= 10f)
        {
            Debug.Log(transform.name  +": Move to x > 10 ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(transform.position.x > 10)
        //{
            //Debug.Log(transform.name +": Move to x > 10");
        //}
        //else
        //{
            //Debug.Log(transform.name + "Smaller than 10");
        //}
    }
}
