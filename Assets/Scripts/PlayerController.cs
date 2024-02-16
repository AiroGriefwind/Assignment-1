using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    private bool isGrounded;

    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform shootPoint; // The position from where the bullet will be instantiated

    public int maxAmmo = 10; // Maximum allowed ammo
    private int currentAmmo; // Current ammo count

    public TMP_Text ammoText; // Reference to UI text displaying ammo count

    void Start()
    {
        currentAmmo = maxAmmo; // Initialize current ammo to maximum
        UpdateAmmoUI(); // Update UI text to display initial ammo count
    }

    void Update()
    {
        // Check if the player is grounded and update the isGrounded variable.
        isGrounded = CheckGrounded();

        // Input for jumping is still handled in Update.
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Check for player input to shoot
        if (Input.GetKeyDown(KeyCode.X)) // Change "Fire1" to the desired button input
        {
            if (currentAmmo > 0)
            {
                Shoot();
                currentAmmo--; // Deduct ammo when shooting
                UpdateAmmoUI(); // Update UI text to reflect ammo consumption
            }
            else
            {
                Debug.Log("Out of ammo!");
                // Play out of ammo sound or show message to the player
            }
        }
    }

    void FixedUpdate()
    {
        // Input for movement is now handled in FixedUpdate.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Apply movement relative to world space
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);

        // Calculate rotation towards movement direction
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    bool CheckGrounded()
    {
        float raycastDistance = 2.0f;
        RaycastHit hit;

        int groundLayerMask = LayerMask.GetMask("Ground");

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayerMask))
        {
            return true;
        }

        return false;
    }

    void Shoot()
    {
        // Instantiate a bullet at the shoot point position and rotation
        GameObject bulletObject = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // Get the BulletController component from the instantiated bullet
        BulletController bulletController = bulletObject.GetComponent<BulletController>();

        if (bulletController != null)
        {
            // Add velocity to the bullet
            Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bulletObject.transform.forward * bulletController.speed;
            }
            else
            {
                Debug.LogError("Bullet Rigidbody component not found!");
            }
        }
        else
        {
            Debug.LogError("BulletController component not found!");
        }
    }

    public void IncreaseAmmo(int amount)
    {
        currentAmmo += amount;
        // Update UI text to reflect the increased ammo count
        UpdateAmmoUI();
    }


    void UpdateAmmoUI()
    {
        // Update the UI text to display current ammo count
        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }
}
