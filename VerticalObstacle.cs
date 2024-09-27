using UnityEngine;

public class VerticalObstacle : MonoBehaviour
{
    public bool randomStartPositionYN;
    public int minPosition, maxPosition, offset;
    public float speed;
    public bool randomSpeedYN;
    public float minSpeed, maxSpeed;
    private float randomSpeed;
    private int randomStartPosition;
    private bool isMovingUp = true;

    void Start()
    {
        randomSpeed = Random.Range(minSpeed, maxSpeed);
        randomStartPosition = Random.Range(minPosition + offset, maxPosition - offset);

        if (randomStartPositionYN)
            transform.position = new Vector3(transform.position.x, randomStartPosition, transform.position.z);
    }

    void Update()
    {
        int moveDirection = isMovingUp ? 1 : -1;
        
        float movSpeed = randomSpeedYN ? randomSpeed : speed;
        transform.position += new Vector3(0, movSpeed * moveDirection, 0) * Time.deltaTime;

        if ((int)transform.position.y == (isMovingUp ? (int)maxPosition : (int)minPosition))        
            isMovingUp = !isMovingUp;        
    }
} 