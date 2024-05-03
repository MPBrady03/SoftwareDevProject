using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // checks if the interacted object is the player
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restarts the scene
        }
    }
}