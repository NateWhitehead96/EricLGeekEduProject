using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public Text LivesText;
    public Text ScoreText;
    public Text WaveText;

    public static int Lives;
    public static int Score;
    public static int Wave;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
