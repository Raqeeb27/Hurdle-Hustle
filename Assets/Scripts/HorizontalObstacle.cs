using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{    
    public bool randomStartPositionYN;
    public int minPosition, maxPosition, offset;
    public float speed;
    public bool randomSpeedYN;
    public float minSpeed, maxSpeed;
    private float randomSpeed;
    private int randomStartPosition;
    private bool isMovingRight = true;

    void Start()
    {
        randomSpeed = Random.Range(minSpeed, maxSpeed);
        randomStartPosition = Random.Range(minPosition + offset, maxPosition - offset);

        if (randomStartPositionYN)
            transform.position = new Vector3(randomStartPosition, transform.position.y, transform.position.z);
    }

    void Update()
    {
        int moveDirection = isMovingRight ? 1 : -1;
        
        float movSpeed = randomSpeedYN ? randomSpeed : speed;
        transform.position += new Vector3(movSpeed * moveDirection, 0, 0) * Time.deltaTime;

        if ((int)transform.position.x == (isMovingRight ? (int)maxPosition : (int)minPosition))        
            isMovingRight = !isMovingRight;        
    }
}