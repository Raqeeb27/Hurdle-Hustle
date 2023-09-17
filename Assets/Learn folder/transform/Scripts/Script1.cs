using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{/*
    bool isMovingUp = true, isMovingRight = true, isMovingForward = true;
    public string horizontalMov;
    public string ranHoriStartPosYN;


    public string vericalMov;
    public string forwardMov;
    
    public string ranVertiStartPosYN;
    public string ranForwStartPosYN;
 
    public int horiMinPosition;
    public int vertiMinPosition;
    public int forwMinPosition;
    public int horiMaxPosition;
    public int vertiMaxPosition;
    public int forwMaxPosition;
    public float horiSpeed;
    public float vertiSpeed;
    public float forwSpeed;
    public string ranHoriSpeedYN;
    public string ranVertiSpeedYN;
    public string ranForwSpeedYN;
    public float horiMinSpeed;
    public float vertiMinSpeed;
    public float forwMinSpeed;
    public float horiMaxSpeed;
    public float vertiMaxSpeed;
    public float forwMaxSpeed;
    private float ranHoriSpeed;
    private float ranVertiSpeed;
    private float ranForwSpeed;
    private int ranHoriStartPos;
    private int ranVertiStartPos;
    private int ranForwStartPos;

    void Start()
    {
        randomSpeed = Random.Range(minSpeed, maxSpeed);
        randomStartPosition = Random.Range(minPosition+2, maxPosition-2);

        if ((movementTypeHV == "Vertical" || movementTypeHV == "V") && (randomStartPositionYN == "Yes" || randomStartPositionYN == "Y"))
            transform.position = new Vector3(transform.position.x, randomStartPosition, transform.position.z);

        else if ((movementTypeHV == "Horizontal" || movementTypeHV == "H") && (randomStartPositionYN == "Yes" || randomStartPositionYN == "Y"))
            transform.position = new Vector3(randomStartPosition, transform.position.y, transform.position.z);


    }

    void Update()
    {
        if (movementTypeHV == "Vertical" || movementTypeHV == "V")
        {
            int moveDirection = isMovingUp ? 1 : -1;

            if (randomSpeedYN == "Yes" || randomSpeedYN == "Y")
                transform.position += new Vector3(0, randomSpeed * moveDirection, 0) * Time.deltaTime;
            else
                transform.position += new Vector3(0, speed * moveDirection, 0) * Time.deltaTime;

            if ((int)transform.position.y == (isMovingUp ? (int)maxPosition : (int)minPosition))
                isMovingUp = !isMovingUp;

        }
        else if (movementTypeHV == "Horizontal" || movementTypeHV == "H")
        {
            int moveDirection = isMovingRight ? 1 : -1;

            if (randomSpeedYN == "Yes" || randomSpeedYN == "Y")
                transform.position += new Vector3(randomSpeed * moveDirection, 0, 0) * Time.deltaTime;
            else
                transform.position += new Vector3(speed * moveDirection, 0, 0) * Time.deltaTime;

            if ((int)transform.position.x == (isMovingRight ? (int)maxPosition : (int)minPosition))
                isMovingRight = !isMovingRight;
        }

    }*/
}
