using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Vector3 startingPosition;
    public float Speed = 8f, jumpSpeed = 5.5f;
    public TextMeshProUGUI lifesNumber, levelCompLifeNum;
    public TextMeshPro playerNameDisplay;
    public float checkedYPosition, checkedZPosition;
    public GameObject checkFlag, blackPanel, levelComPanel, levelFailPanel;
    public Color greenColor, redColor;
    private bool floorCollosion = true, isNotTrigerring = true, checkNotCrossed = true, notRestart = true;
    private int lifes = 3;
    private float lastTriggerTime = 0f, triggerCooldown = 0.3f;    


    private void OnCollisionEnter(Collision collision)
    {
        floorCollosion = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        floorCollosion = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        floorCollosion = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (Time.time - lastTriggerTime >= triggerCooldown)
        {
            lastTriggerTime = Time.time;

            if (collider.CompareTag("Finishpoint"))
            {
                Debug.Log("LEVEL COMPLETED");
                blackPanel.SetActive(true);
                levelComPanel.SetActive(true);
                Time.timeScale = 0f;
            }

            if (collider.CompareTag("Checkpoint"))
            {
                checkFlag.GetComponent<Renderer>().material.color = greenColor;
                checkedYPosition = transform.position.y;
                checkedZPosition = transform.position.z;
                notRestart = true;
                isNotTrigerring = false;
            }

            if (collider.tag != "Checkpoint" && collider.tag != "Finishpoint")
            {
                lifes = lifes - 1;
                lifesNumber.text = lifes + "";
                levelCompLifeNum.text = lifes + "";
                if (lifes == 0)
                {
                    Debug.Log("LEVEL FAILED");
                    blackPanel.SetActive(true);
                    levelFailPanel.SetActive(true);
                    Time.timeScale = 0f;
                }
            }

            if (isNotTrigerring)
            {
                if (!checkNotCrossed && notRestart)
                {
                    Debug.Log("!!! HIT !!!");
                    Checkpoint();
                }
                else
                {
                    Debug.Log("!!! HIT !!!");
                    StartingPoint();
                }
            }
            else
            {
                Debug.Log("Checkpoint Cleared !!!");
                checkNotCrossed = false;
            }
        }
    }


    public void StartingPoint()
    {
        transform.position = startingPosition;
    }

    public void Checkpoint()
    {
        transform.position = new Vector3(0f, checkedYPosition + 2f, checkedZPosition + 1f);
    }

    public void RestartGame()
    {
        StartingPoint();
        Debug.Log("New Game");
        notRestart = false;
        checkFlag.GetComponent<Renderer>().material.color = redColor;
        lifes = 3;
        lifesNumber.text = lifes + "";
        levelCompLifeNum.text = lifes + "";
    }

    void Start()
    {
        startingPosition = transform.position;
        redColor = checkFlag.GetComponent<Renderer>().material.color;
        lifesNumber.text = lifes + "";
        levelCompLifeNum.text = lifes + "";

        if (PlayerPrefs.GetString("PlayerName") == "")
            playerNameDisplay.text = "Player";
        else
            playerNameDisplay.text = PlayerPrefs.GetString("PlayerName");

        if (PlayerPrefs.GetFloat("PlayerSpeed") == 0)
            Speed = 4f;
        else
            Speed = PlayerPrefs.GetFloat("PlayerSpeed");
    }

    void Update()
    {
        isNotTrigerring = true;
        float horizontalMovement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical");
        float verticalMovement = verticalMove > 0f ? verticalMove * Speed * Time.deltaTime : 0f;

        transform.Translate(horizontalMovement, 0, verticalMovement);

        if (Input.GetKey("space") && floorCollosion)
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);

    }
}