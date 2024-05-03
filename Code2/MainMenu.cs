/*****
Braeden Kurfman
Software Engineering
Testing Grounds
*****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Tutorial"); // loads tutorial
    }

    public void QuitGame(){ // closes game
    }
}
