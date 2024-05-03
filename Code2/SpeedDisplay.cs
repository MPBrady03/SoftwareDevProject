using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public PlayerMovement PM; // Reference to the CubeMovement script
    public Text speedText; // Reference to the UI Text element

    void Update()
    {
        if (PM != null && speedText != null)
        {
            float currentSpeed = PM.GetCurrentSpeed();
            speedText.text = "Speed: " + currentSpeed.ToString("F1") + " m/s"; // Display speed with one decimal place
        }
    }
}