using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow (your cube).

    public Vector3 offset = new Vector3(0f, 7f, -10f); // Offset from the target position.

    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement.

    void LateUpdate()
    {
        // Check if the target is assigned.
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Target is not assigned!");
            return;
        }

        // Calculate the desired camera position based on the target's position and offset.
        Vector3 desiredPosition = target.position + offset;

        // Use Lerp to smoothly move the camera to the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the new camera position.
        transform.position = smoothedPosition;

        // Make the camera look at the target (your cube).
        transform.LookAt(target);
    }
}
