using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // checks if the interacted object is the player
        {
            SceneManager.LoadScene("Level1"); // loads level 1
        }
    }
}
