using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour
{
    public string movementTypeHV;
    public string randomStartPositionYN;
    bool isMovingUp = true, isMovingRight = true;
    public int minPosition;
    public int maxPosition;
    public float speed;
    public string randomSpeedYN;
    public float minSpeed;
    public float maxSpeed;
    private float randomSpeed;
    private int randomStartPosition;

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

    }
}