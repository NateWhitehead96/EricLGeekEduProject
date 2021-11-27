using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public RoadManager roadManager;
    public int score;

    private GameObject LogPosition;
    public bool OnLog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown("w"))
        {
            OnLog = false;
            LogPosition = null;
            transform.Translate(Vector3.forward * moveSpeed);
            AddNewRoad();
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(Vector3.left * moveSpeed);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(Vector3.right * moveSpeed);
        }

        if (OnLog)
        {
            transform.position = LogPosition.transform.position;
        }

        if(transform.position.y < -2)
        {
            SceneManager.LoadScene("MainMenu");
        }

        //float xDirection = Input.GetAxis("Horizontal");
        //float zDirection = Input.GetAxis("Vertical");

        //transform.position = new Vector3(transform.position.x + xDirection * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z + zDirection * moveSpeed * Time.deltaTime);
    }

    public void AddNewRoad() // spawn a new road
    {
        roadManager.SpawnRoad();
        score++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            print("Drowning lol");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Log")) // when we collide with the log/land on the log we move with it
        {
            LogPosition = collision.gameObject;
            OnLog = true;
        }

        if (collision.gameObject.CompareTag("Car"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void OnCollisionExit(Collision collision) // when we jump off the log
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            LogPosition = null;
            OnLog = false;
        }
    }
}
