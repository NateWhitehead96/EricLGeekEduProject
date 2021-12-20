using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    public int LevelToLoad; // will the the level index 
    public int CurrentLevel; // our current level

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(GameManager.instance.CurrentLevel < CurrentLevel) // if our current level is less than the level we're beating then set it to this level
                GameManager.instance.CurrentLevel = CurrentLevel;
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
