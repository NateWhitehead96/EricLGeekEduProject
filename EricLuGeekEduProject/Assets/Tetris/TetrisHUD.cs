using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisHUD : MonoBehaviour
{
    public Text Score;
    public static int GameScore;
    public static int OldScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = GameScore.ToString();
    }
}
