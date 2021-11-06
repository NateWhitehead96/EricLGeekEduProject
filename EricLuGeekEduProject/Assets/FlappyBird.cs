using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{
    public int jumpForce;
    public Rigidbody2D rb;
    public int score;
    public int YBound; // determine when we're offscreen

    // Update is called once per frame
    void Update()
    {
        Jump();
        SetPlayerRotation();
        CheckInBounds();
    }

    void Jump() // jumping input
    {
        if (Input.GetKeyDown("space")) // when he hit the spacebar do something aka jump
        {
            rb.AddForce(new Vector3(0, jumpForce));
        }
    }

    void SetPlayerRotation() // rotate the player a little when jumping and falling
    {
        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 10));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -10));
        }
    }

    void CheckInBounds()
    {
        if(transform.position.y > YBound || transform.position.y < -YBound) // if we're above or below the play area move to lose scene
        {
            MoveToLoseScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // if we're going through the middle of the pipes
        {
            score++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipes")) // hitting the pipes
        {
            print("We dead son.");
            MoveToLoseScene();
        }
    }

    void MoveToLoseScene()
    {
        SceneManager.LoadScene(1);
    }
}
