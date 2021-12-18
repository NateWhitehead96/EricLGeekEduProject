using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayFlappyBird()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PlayAsteroids()
    {
        SceneManager.LoadScene("Asteroids");
    }
    public void PlayCrossyRoad()
    {
        SceneManager.LoadScene("CrossyRoad");
    }

    public void PlayTetris()
    {
        SceneManager.LoadScene("Tetris");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
