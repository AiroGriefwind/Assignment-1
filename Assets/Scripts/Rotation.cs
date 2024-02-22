using UnityEngine;

public class SphereOrbit : MonoBehaviour
{
    public Transform centerPoint; // Reference to the center point GameObject
    public float orbitSpeed = 10f; // Speed of rotation around the center
    public float orbitRadius = 5f; // Distance from the center point

    private Vector3 orbitPosition; // Current position of the sphere in orbit

    void Start()
    {
        // Initialize orbit position relative to the center point
        UpdateOrbitPosition();
    }

    void Update()
    {
        // Rotate the sphere around the center point
        transform.RotateAround(centerPoint.position, Vector3.up, orbitSpeed * Time.deltaTime);

        // Update the position of the sphere based on the orbit position
        transform.position = orbitPosition;

        // Update the orbit position for the next frame
        UpdateOrbitPosition();
    }

    void UpdateOrbitPosition()
    {
        // Calculate the orbit position relative to the center point
        orbitPosition = centerPoint.position + (Quaternion.Euler(0, Time.time * orbitSpeed, 0) * (Vector3.right * orbitRadius));
    }
}
