using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public int moveSpeed; // how fast it goes
    public int direction = -1; // the x axis direction
    public float leftPoint; // the max x value on the left the enemy will travel
    public float rightPoint; // the max x value to the right the enemy will travel

    private SpriteRenderer sprite; // help with flipping the sprite on the xaxis
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y); 
        if(transform.position.x <= leftPoint)
        {
            direction = 1; // change direction to go to the right once at it's left point
            sprite.flipX = true; // sprite will flip direction
        }
        if(transform.position.x >= rightPoint)
        {
            direction = -1; // change direction to go to the left
            sprite.flipX = false; // flip direction the sprite is facing
        }
    }
}
