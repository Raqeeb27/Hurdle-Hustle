using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMov : MonoBehaviour
{
    public bool b = true;
    private bool c = true;

    void Update(){
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") > 0){
            if (b){
                if (transform.rotation.x <= 0.02603f && c){
                    c = false;
                    transform.Rotate(65 * Time.deltaTime, 0, 0);
                }
                else if (transform.rotation.x <= 0.09f){
                    b = true;
                    transform.Rotate(65 * Time.deltaTime, 0, 0);
                }
                else
                    b = false;
            }
            else{
                if (transform.rotation.x >= -0.0303f)
                    transform.Rotate(-65 * Time.deltaTime, 0, 0);
                else
                    b = true;
            }
        }
    }
}