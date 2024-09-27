using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 startingPosition;
    public Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor;
    public float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}