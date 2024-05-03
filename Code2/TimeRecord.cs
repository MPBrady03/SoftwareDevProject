using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class TimeRecord : MonoBehaviour
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
}
