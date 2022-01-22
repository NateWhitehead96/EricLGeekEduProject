using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public int health;

    public Transform Checkpoint; // respawn point
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score += collision.gameObject.GetComponent<CoinBob>().scoreIncrease;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Deathplane"))
        {
            // we die and restart from checkpoint
            transform.position = Checkpoint.position;
        }
    }
}
