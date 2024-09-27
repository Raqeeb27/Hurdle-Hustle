using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMov : MonoBehaviour
{
    public bool b = true;
    private bool c = true;
    
    void Update(){
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") > 0){
            if (b){
                if (transform.rotation.x <= -0.22f && c){
                    c = false;
                    transform.Rotate(65 * Time.deltaTime, 0, 0);
                }
                else if (transform.rotation.x <= -0.15f){
                    b = true;
                    transform.Rotate(65 * Time.deltaTime, 0, 0);
                }
                else
                    b = false;                
            }
            else{
                if (transform.rotation.x >= -0.27f)
                    transform.Rotate(-65 * Time.deltaTime, 0, 0);                
                else                
                    b = true;                
            }            
        }
    }
}