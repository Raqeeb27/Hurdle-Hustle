using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float speed = 35f;
    public char Axis ;
   
    void Update()
    {
        if(Axis == 'x' || Axis == 'X')
            transform.Rotate(speed*Time.deltaTime,0,0);

        if(Axis == 'y' || Axis == 'Y')
            transform.Rotate(0,speed*Time.deltaTime,0);
            
        if(Axis == 'z' || Axis == 'Z')
            transform.Rotate(0,0,speed*Time.deltaTime);
    }
}