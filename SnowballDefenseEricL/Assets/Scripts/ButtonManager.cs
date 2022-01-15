using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        // start our game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void ControlsScene()
    {
        // open the controls scene
        SceneManager.LoadScene("ControlsScene");
    }

    public void ExitGame()
    {
        // quit or close the game
        Application.Quit();
    }

    public void MainMenu()
    {
        // open main menu
        SceneManager.LoadScene("MainMenu");
    }
}
