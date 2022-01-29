using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBob : MonoBehaviour
{
    public float moveSpeed; // how fast it moves
    public int direction; // the direction its going
    public int scoreIncrease; // how much the coin is worth

    public float topValue; // how high up can the coin go
    public float botValue; // how low can ya go

    private void Start()
    {
        topValue = transform.position.y + 0.5f;
        botValue = transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime); // movement of the coin aka the bob aka the sponge

        if(transform.position.y > topValue)
        {
            direction = -1;
        }
        if(transform.position.y < botValue)
        {
            direction = 1;
        }
    }
}
