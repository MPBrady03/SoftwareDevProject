using UnityEngine;

public class GunFollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Camera mainCamera; // Reference to the main camera
    public float distanceFromPlayer = 2.0f; // Desired distance from the player
    public float offsetX = 1.0f; // Horizontal offset from the center of the screen

    void LateUpdate()
    {
        if (player != null && mainCamera != null)
        {
            // Calculate the target position based on the player's position and orientation relative to the camera's view
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;

            Vector3 targetPosition = player.position + cameraForward * distanceFromPlayer + cameraRight * offsetX;

            // Set the position of the grappling gun to the target position
            transform.position = targetPosition;
        }
        else
        {
            Debug.LogWarning("Player or camera reference not set in GrapplingGunController script.");
        }
    }
}