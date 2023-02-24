using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {
    
    //Get into play scene when click on play button
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Display "Quit game!" on console when click on quit button
    public void QuitGame ()
    {
        string quit = "Quit game!"; //making a string variable to display
        Debug.Log(quit); //display variable on console
        Application.Quit();
    }
}
