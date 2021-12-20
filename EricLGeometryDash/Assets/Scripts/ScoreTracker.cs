using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Text ScoreText;
    public float score;
    public float oldScore;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        ScoreText.text = "Score: " + score.ToString("n0");

        if(score >= oldScore + 10)
        {
            oldScore += 10;
            int randColor = Random.Range(0, 5);
            if(randColor == 0)
            {
                camera.backgroundColor = Color.Lerp(camera.backgroundColor, Color.blue, Time.time);
            }
            if (randColor == 1)
            {
                camera.backgroundColor = Color.Lerp(camera.backgroundColor, Color.red, Time.time);
            }
            if (randColor == 2)
            {
                camera.backgroundColor = Color.Lerp(camera.backgroundColor, Color.green, Time.time);
            }
            if (randColor == 3)
            {
                camera.backgroundColor = Color.Lerp(camera.backgroundColor, Color.yellow, Time.time);
            }
            if (randColor == 4)
            {
                camera.backgroundColor = Color.Lerp(camera.backgroundColor, Color.magenta, Time.time);
            }
            
        }
    }
}
