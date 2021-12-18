using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] // what this does is it shows the variable in the editor without allowing other classes to access this variable
    private float moveSpeed;
    [SerializeField]
    private bool jumping = false;
    [SerializeField] private float jumpForce;
    public Rigidbody2D rb;
    public Transform childTransform; // the player sprite

    public Vector3 LandingDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AutoRun();
        Jump();
    }

    void AutoRun() // keep moving out player forward
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // this will move us to the right at our speed
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumping = true;
            childTransform.Rotate(Vector3.forward * -180);
            LandingDistance = transform.position;
            print("Takeoff at " + LandingDistance);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // when we collide with the ground we can jump again
        {
            jumping = false;
            LandingDistance = transform.position;
            print("Landing at " + LandingDistance);
        }
        if (collision.gameObject.CompareTag("Hazard")) // when we hit a hazard, go back to the start and reset our score
        {
            transform.position = Vector3.zero;
            FindObjectOfType<ScoreTracker>().score = 0;
            FindObjectOfType<ScoreTracker>().oldScore = 0;
        }
    }
}
