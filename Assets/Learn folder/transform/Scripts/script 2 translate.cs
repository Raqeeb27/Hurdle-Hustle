using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script2translate : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0f,0f,0.1f,Space.World);
    }
}
