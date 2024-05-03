using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TopDeathBarrier : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Transform mainCameraTransform;

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Player")) // checks if the interacted object is the player
        {
            ReverseGravityDirection();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restarts the scene

        }
    }

    void ReverseGravityDirection()
    {
        Physics.gravity = -Physics.gravity;

        // Rotate player
        playerRigidbody.transform.Rotate(180f, 0f, 0f, Space.Self);

        // Rotate camera
        mainCameraTransform.Rotate(180f, 0f, 0f, Space.Self);
    }
    
}
