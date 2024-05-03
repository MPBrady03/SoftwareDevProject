using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject BackButton;
     // when the options button is clicked, the settings menu is enabled
    public void OnOptionsButtonPressed()
    {
        if (SettingsMenu != null)
        {
            SettingsMenu.SetActive(true); // Enable the menu
        }
    }

    public void OnBackButtonPressed(){
        if(BackButton != null){
            SettingsMenu.SetActive(false); // disables the menu
        }
    }
}
