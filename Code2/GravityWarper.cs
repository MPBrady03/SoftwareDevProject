/*****
Braeden Kurfman
Software Engineering
Testing Grounds
*****/


//Credit to Greyseth on youtube for help with this code : https://www.youtube.com/watch?v=0qAW_515lMw


using UnityEngine;
public class GravityWarper : MonoBehaviour
{
    // reference to player body
    public Rigidbody playerRigidbody;

    // camera reference
    public Transform mainCameraTransform;

    // Gravity direction
    public static bool isGravityReversed = false;

    // Activate when the player collides with the gravity warper
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reverse gravity and flip player and camera
            isGravityReversed = !isGravityReversed;
            ReverseGravityDirection();
        }
    }

    // Function to reverse gravity direction and flip player and camera
    void ReverseGravityDirection()
    {
        Physics.gravity = -Physics.gravity;

        // Rotate player
        playerRigidbody.transform.Rotate(180f, 0f, 0f, Space.Self);

        // Rotate camera
        mainCameraTransform.Rotate(180f, 0f, 0f, Space.Self);
    }
}