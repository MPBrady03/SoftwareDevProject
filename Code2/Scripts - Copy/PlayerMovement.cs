using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    public float defaultSpeed = 70f;
    public float walkSpeed = 70f; // Movement speed
    public float jumpForce = 10f; // Jump force
    public float sprintSpeed = 70f * 1.5f; //Sprint speed
    public float speedBoostDuration = 10f; //speed boost time

    public GameObject spherePrefab;
    Rigidbody rb;

    bool isGrounded;
    private Vector3 swingDirection;
    private bool isSpeedBoosted;
    private float currentSpeed;
    private Vector3 grapplePointPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
       // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Check if the player is swinging with the grappling hook and spacebar is pressed
        /***
        if (isSwinging && Input.GetKey(KeyCode.Space))
        {
            // Calculate direction towards the grappling hook point
            Vector3 hookDirection = (grapplePointPosition - transform.position).normalized;
            // Set player's velocity towards the grappling hook point
            rb.velocity = hookDirection * currentSpeed * 2;
        }
        ***/
    }
    void FixedUpdate()
    {
        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + move * currentSpeed * Time.deltaTime);

        
           // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }

         if (collision.gameObject.CompareTag("SpeedBoost") && !isSpeedBoosted)
        {
            // Activates speed boost if not already boosted.
            StartCoroutine(ActivateSpeedBoost());
            // Destroys the object so that it goes away when touched
            Destroy(collision.gameObject);
        }
    }

     IEnumerator ActivateSpeedBoost(){
        isSpeedBoosted = true;
        walkSpeed = defaultSpeed * 1.5f; // Double the walk speed
        sprintSpeed = defaultSpeed * 3f;
        yield return new WaitForSeconds(speedBoostDuration);

        // Reset walk speed after the duration
        walkSpeed = defaultSpeed;
        sprintSpeed = walkSpeed * 1.5f;
        isSpeedBoosted = false;
    }

  

    public float GetCurrentSpeed(){
        return walkSpeed;
    }
}