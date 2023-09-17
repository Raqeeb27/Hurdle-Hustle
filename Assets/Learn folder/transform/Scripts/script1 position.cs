using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1position : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"{transform.position.x}  {transform.position.y}  {transform.position.z}");
        

        transform.position = new Vector3(0f,0f,5f);  //  or local position
    }

    void Update()
    {
        //or local position
        transform.position = transform.position + new Vector3(0f,0f,0.1f) * Time.deltaTime;
    }
}



