using UnityEngine;

public class ForwordObstcle : MonoBehaviour
{
    public bool randomStartPositionYN;
    public int minPosition, maxPosition, offset;
    public float speed;
    public bool randomSpeedYN;
    public float minSpeed, maxSpeed;
    private float randomSpeed;
    private int randomStartPosition;
    private bool isMovingForward = true;

    void Start()
    {
        randomSpeed = Random.Range(minSpeed, maxSpeed);
        randomStartPosition = Random.Range(minPosition + offset, maxPosition - offset);

        if (randomStartPositionYN)
            transform.position = new Vector3(transform.position.x, transform.position.y, randomStartPosition);
    }

    void Update()
    {
        int moveDirection = isMovingForward ? 1 : -1;

        float movSpeed = randomSpeedYN ? randomSpeed : speed;
        transform.position += new Vector3(0, 0, movSpeed * moveDirection) * Time.deltaTime;

        if ((int)transform.position.z == (isMovingForward ? (int)maxPosition : (int)minPosition))
            isMovingForward = !isMovingForward;
    }
}