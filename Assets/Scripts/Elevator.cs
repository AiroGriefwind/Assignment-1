using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Speed of the elevator
    public float maxHeight = 10.0f; // Maximum height the elevator can reach
    public float minHeight = 0.0f;  // Minimum height the elevator can go to
    private bool goingUp = true;    // Flag to track the elevator's direction

    void Update()
    {
        MoveElevator();
    }

    void MoveElevator()
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= maxHeight)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= minHeight)
            {
                goingUp = true;
            }
        }
    }
}
