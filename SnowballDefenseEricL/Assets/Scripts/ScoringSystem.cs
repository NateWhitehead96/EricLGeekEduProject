using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public Text LivesText;
    public Text ScoreText;
    public Text WaveText;
    public Text SnowballSize;
    public Text ShootSpeed;

    public static int Lives;
    public static int Score;
    public static int Wave;

    public ShootSnowball snowball;
    // Start is called before the first frame update
    void Start()
    {
        snowball = FindObjectOfType<ShootSnowball>();
        Lives = 3;
        Score = 0;
        Wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + Lives;
        ScoreText.text = "Score: " + Score;
        WaveText.text = "Wave: " + Wave;
        SnowballSize.text = "Snowball Size: " + snowball.snowballSize;
        ShootSpeed.text = "Shoot Speed: " + snowball.shootSpeed;

        ScoreKeeper.instance.score = Score; // store the score to our score keeper

        if(Lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
