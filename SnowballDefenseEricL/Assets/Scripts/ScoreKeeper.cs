using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;
    public int score;

    private void Awake() // singleton design pattern to make sure we only have 1 scorekeeper in our game
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene")) // everytime we reenter the play scene, wipe our score
        {
            score = 0;
        }
    }
}
