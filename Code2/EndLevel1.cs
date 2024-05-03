using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevel1 : MonoBehaviour
{
    private float startTime;
    private float endTime;

    void Start()
    {
        // Record the start time
        startTime = Time.time;
    }

     public void LoadNextScene()
    {
        // Record the end time of the level
        endTime = Time.time;

        // Calculate the total level time
        float totalTime = endTime - startTime;

        // Save the time in a variable
        PlayerPrefs.SetFloat("TotalTime", totalTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // checks if the interacted object is the player
        {
            LoadNextScene();
            SceneManager.LoadScene("End"); // loads level 1
        }
    }

}

   
