using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float turningSpeed = 100.0f;

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        bool isWalking = vertical != 0f;
        animator.SetBool("isWalking", isWalking);

        // Rotate the character
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * turningSpeed * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        // Move the character using Rigidbody
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * vertical * movementSpeed;
        rb.AddForce(movement, ForceMode.VelocityChange); // Use ForceMode.VelocityChange for an immediate change in velocity, ignoring the mass.
    }
}
