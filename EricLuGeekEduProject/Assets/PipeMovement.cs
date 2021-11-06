using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public int moveSpeed; // how fast the pipes move
    public float XBounds; // the bounds where the pipes will delete themselves
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z); // move the pipes to the left

        if(transform.position.x <= XBounds) // if the pipes are offscreen destroy the game object
        {
            Destroy(gameObject);
        }
    }
}
