using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // our speed
    public float jumpForce; // how high we jump
    public SpriteRenderer sprite; // reference to our sprite
    public Rigidbody2D rb; // our rigidbody/physics body
    public Animator animator; // our animation controller

    public bool walking; // this variable will know if we're walking or not
    public bool jumping; // vairable for knowing if we're jumping or not
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) // when the D key is pressed/held down
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = false;
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.D)) // when the D key is let go
        {
            walking = false;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = true;
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            walking = false;
        }

        animator.SetBool("isWalking", walking);
        animator.SetBool("isJumping", jumping);

        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
}
