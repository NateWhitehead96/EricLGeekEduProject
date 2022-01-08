using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1; // set time scale back to 1
        gameObject.SetActive(false); // hide the canvas
    }
}
