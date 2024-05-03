/*****
Braeden Kurfman
Software Engineering
Testing Grounds
*****/

using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // Sensitivity for mouse movement
    public Transform playerBody; // Reference to the player's body or character controller

    float xRotation = 0f;

    void Start()
    {
        // Lock cursor to the center of the screen and hide it
        

    }

    void Update()
     {
        if(!PauseMenu.isPaused){
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player body horizontally based on mouse movement
        playerBody.Rotate(Vector3.up * mouseX);

        // Calculate vertical rotation for the camera
        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation to prevent flipping

        // Apply vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}