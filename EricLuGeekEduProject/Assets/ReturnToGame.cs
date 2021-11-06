using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    public int LeveltoLoad; // the index of the level we want to load. MAKE SURE THE LEVEL TO LOAD'S INDEX IS IN THE BUILD PATH
    public void PlayAgain() // the button we press to play again
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
}
