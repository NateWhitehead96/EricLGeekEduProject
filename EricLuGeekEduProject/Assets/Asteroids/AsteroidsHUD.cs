using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsHUD : MonoBehaviour
{
    public Text ScoreText;
    public Slider HealthBar;
    public ShipBehaviour player;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = player.Health;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + player.score;
        HealthBar.value = player.Health;
    }
}
