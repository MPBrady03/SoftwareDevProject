using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Squid : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Rigidbody playerRigidbody;
    public Transform mainCameraTransform;
    public float speed = 5f; // Speed at which the object flies towards the player

    void Update()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the object towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // Ignore collisions with other objects
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
         if (collision.gameObject.CompareTag("Player")) // checks if the interacted object is the player
        {
            ReverseGravityDirection();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restarts the scene
        }

        // Ignore collisions with other objects
        Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
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
