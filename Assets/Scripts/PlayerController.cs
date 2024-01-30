using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    private bool isGrounded;

    void Start()
    {
        // Any setup code you might have.
    }

    void Update()
    {
        // Check if the player is grounded and update the isGrounded variable.
        isGrounded = CheckGrounded();

        // Add a debug message to check if isGrounded is true.
        // if (isGrounded)
        // {
        //     Debug.Log("Player is grounded");
        // }

        // Input for jumping is still handled in Update.//CITED From GPT
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
     
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }

    bool CheckGrounded() //CITED From GPT
    {
        float raycastDistance = 2.0f;
        RaycastHit hit;

        int groundLayerMask = LayerMask.GetMask("Ground"); // Get the layer mask for the "Ground" layer.

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayerMask))
        {
            return true;
        }

        return false;
    }
}
