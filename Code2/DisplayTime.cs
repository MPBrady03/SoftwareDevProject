using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // allows for tracking of time

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Start()
    {
        // retrieve the total time
        float totalTime = PlayerPrefs.GetFloat("TotalTime");

        // convert total time to minutes and seconds
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);
       // displays time in format
        timeText.text = string.Format("Total Time: {0:00}:{1:00}", minutes, seconds);
    }
}