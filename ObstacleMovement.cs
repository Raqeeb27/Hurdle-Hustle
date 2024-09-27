/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{    
    public string horizontal = "Horizontal Movement";
    public bool hRandomStartPositionYN;
    public int hMinPosition, hMaxPosition, hOffset;
    public float hSpeed;
    public bool hRandomSpeedYN;
    public float hMinSpeed, hMaxSpeed;
    private float hRandomSpeed;
    private int hRandomStartPosition;
    private bool isMovingRight = true;

    public string vertical = "Vertical Movement" ;
    public bool vRandomStartPositionYN;
    public int vMinPosition, vMaxPosition, vOffset;
    public float vSpeed;
    public bool vRandomSpeedYN;
    public float vMinSpeed, vMaxSpeed;
    private float vRandomSpeed;
    private int vRandomStartPosition;
    private bool isMovingUp = true;

    public string forword = "Forword Movement";
    public bool fRandomStartPositionYN;
    public int fMinPosition, fMaxPosition, fOffset;
    public float fSpeed;
    public bool fRandomSpeedYN;
    public float fMinSpeed, fMaxSpeed;
    private float fRandomSpeed;
    private int fRandomStartPosition;
    private bool isMovingForward = true;

    void Start()
    {
        hRandomSpeed = Random.Range(hMinSpeed, hMaxSpeed);
        hRandomStartPosition = Random.Range(hMinPosition + hOffset, hMaxPosition + 1 - hOffset);

        vRandomSpeed = Random.Range(vMinSpeed, vMaxSpeed);
        vRandomStartPosition = Random.Range(vMinPosition + vOffset, vMaxPosition + 1 - vOffset);

        fRandomSpeed = Random.Range(fMinSpeed, fMaxSpeed);
        fRandomStartPosition = Random.Range(fMinPosition + fOffset, fMaxPosition + 1 - fOffset);

        if (hRandomStartPositionYN)
            transform.position = new Vector3(hRandomStartPosition, transform.position.y, transform.position.z);      

        if (vRandomStartPositionYN)
            transform.position = new Vector3(transform.position.x, vRandomStartPosition, transform.position.z);        

        if (fRandomStartPositionYN)
            transform.position = new Vector3(transform.position.x, transform.position.y, fRandomStartPosition);
    }

    void Update()
    {
        int hMoveDirection = isMovingRight ? 1 : -1;
        int vMoveDirection = isMovingUp ? 1 : -1;
        int fMoveDirection = isMovingForward ? 1 : -1;
        
        float hMovSpeed = hRandomSpeedYN ? hRandomSpeed : hSpeed;
        transform.position += new Vector3(hMovSpeed * hMoveDirection, 0, 0) * Time.deltaTime;

        float vMovSpeed = vRandomSpeedYN ? vRandomSpeed : vSpeed;
        transform.position += new Vector3(0, vMovSpeed * vMoveDirection, 0) * Time.deltaTime;

        float fMovSpeed = fRandomSpeedYN ? fRandomSpeed : fSpeed;
        transform.position += new Vector3(0, 0, fMovSpeed * fMoveDirection) * Time.deltaTime;

        if ((int)transform.position.x == (isMovingRight ? (int)hMaxPosition : (int)hMinPosition))        
            isMovingRight = !isMovingRight;   
        
        if ((int)transform.position.y == (isMovingUp ? (int)vMaxPosition : (int)vMinPosition))        
            isMovingUp = !isMovingUp;     
        
        if ((int)transform.position.z == (isMovingForward ? (int)fMaxPosition : (int)fMinPosition))        
            isMovingForward = !isMovingForward;        
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings
    {
        public string movementName;
        public bool randomStartPositionYN = false;
        public int minPosition, maxPosition, offset;
        public float speed;
        public bool randomSpeedYN = false;
        public float minSpeed, maxSpeed;
        [HideInInspector] public float randomSpeed;
        [HideInInspector] public int randomStartPosition;
        [HideInInspector] public bool isMovingPositive = true;
    }

    public List<MovementSettings> movementSettings;

    private void Start()
    {
        foreach (var settings in movementSettings)
        {
            settings.randomSpeed = Random.Range(settings.minSpeed, settings.maxSpeed);
            settings.randomStartPosition = Random.Range(settings.minPosition + settings.offset, settings.maxPosition + 1 - settings.offset);

            if (settings.randomStartPositionYN)
            {
                Vector3 startPosition = transform.position;

                if (settings.movementName == "H")
                    startPosition.x = settings.randomStartPosition;
                else if (settings.movementName == "V")
                    startPosition.y = settings.randomStartPosition;
                else if (settings.movementName == "F")
                    startPosition.z = settings.randomStartPosition;

                transform.position = startPosition;
            }
        }
    }

    private void Update()
    {
        foreach (var settings in movementSettings)
        {
            int moveDirection = settings.isMovingPositive ? 1 : -1;
            float moveSpeed = settings.randomSpeedYN ? settings.randomSpeed : settings.speed;

            if (settings.movementName == "H"){
                transform.position += new Vector3(moveSpeed * moveDirection, 0, 0) * Time.deltaTime;
                //Debug.Log(transform.position.x);
                if ((int)transform.position.x == (settings.isMovingPositive ? settings.maxPosition : settings.minPosition))
                    settings.isMovingPositive = !settings.isMovingPositive;
            }

            else if (settings.movementName == "V"){
                transform.position += new Vector3(0, moveSpeed * moveDirection, 0) * Time.deltaTime;
                //Debug.Log(transform.position.y);
                if ((int)transform.position.y == (settings.isMovingPositive ? settings.maxPosition : settings.minPosition))
                    settings.isMovingPositive = !settings.isMovingPositive;
            }

            else if (settings.movementName == "F"){
                transform.position += new Vector3(0, 0, moveSpeed * moveDirection) * Time.deltaTime;
                if ((int)transform.position.z == (settings.isMovingPositive ? settings.maxPosition : settings.minPosition))
                    settings.isMovingPositive = !settings.isMovingPositive;
            }


            
        }
    }
}