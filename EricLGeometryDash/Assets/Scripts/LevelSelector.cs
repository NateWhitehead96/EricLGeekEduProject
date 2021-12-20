using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] LevelButtons;
    private void Start()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i].SetActive(false);
        }
        LevelButtons[0].SetActive(true);
        if(GameManager.instance.CurrentLevel >= 1)
        {
            LevelButtons[1].SetActive(true);
        }
    }
    public void PlayLevelOne()
    {
        SceneManager.LoadScene(0);
    }
}
