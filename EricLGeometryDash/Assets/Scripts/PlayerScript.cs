using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Canvas PauseUI;
    public Animator animator;
    public bool flip;
    public bool EndlessMode;
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.gameObject.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.P)) // pausing in unity. Time.timeScale controls the speed of time
        {
            if (PauseUI.gameObject.activeInHierarchy)
            {
                PauseUI.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PauseUI.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumping = true;
            //childTransform.Rotate(Vector3.forward * -180);
            LandingDistance = transform.position;
            flip = !flip;
            animator.SetBool("Flipped", flip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // when we collide with the ground we can jump again
        {
            jumping = false;
            LandingDistance = transform.position;
        }
        if (collision.gameObject.CompareTag("Hazard")) // when we hit a hazard, go back to the start and reset our score
        {
            if (EndlessMode)
            {
                SceneManager.LoadScene("EndlessRunner");
            }
            transform.position = Vector3.zero;
            FindObjectOfType<ScoreTracker>().score = 0;
            FindObjectOfType<ScoreTracker>().oldScore = 0;
        }
    }
}
