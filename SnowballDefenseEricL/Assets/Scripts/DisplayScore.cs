using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    public Text ScoreText;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Your final score: " + ScoreKeeper.instance.score.ToString();
    }
}
