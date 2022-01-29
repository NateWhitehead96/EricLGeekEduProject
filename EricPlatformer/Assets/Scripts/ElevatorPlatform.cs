using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public float moveSpeed; // how fast the elevator rises
    public float topEnd; // top position
    public float bottomEnd; // the origianl position
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        if(transform.position.y >= topEnd || transform.position.y <= bottomEnd) // if the elevator is at the top or bottom, stop moving
        {
            moveSpeed = 0; // stop moving the thing
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 2; // add move speed
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = -2; // subtract move speed
        }
    }
}
