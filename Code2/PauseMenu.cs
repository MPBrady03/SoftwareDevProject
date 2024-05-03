/*****
Braeden Kurfman
Software Engineering
Testing Grounds
*****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){ // if the ESC key is pressed, pause the game
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){ // pauses the game by setting every objects time to zero besides the pause button objects
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void ResumeGame(){ // resumes the game
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void routeMainMenu(){ // back to the main menu scene
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }
}
