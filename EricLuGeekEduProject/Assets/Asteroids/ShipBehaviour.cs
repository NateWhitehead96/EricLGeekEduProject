using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBehaviour : MonoBehaviour
{
    public float moveSpeed; // how fast we move
    public Rigidbody2D rb2d; // our physics body
    public int turnSpeed; // how fast we rotate

    // bounds checking variables
    public float XBounds;
    public float YBounds;

    // shooty stuff
    public GameObject Bullet; // the bullet we are going to shoot
    public Transform ShootPosition; // the position for our bullet
    public float bulletForce; // how fast the bullet goes

    public int score;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        Shoot();
    }

    void Move()
    {
        // going forward
        if (Input.GetKey("w"))
        {
            rb2d.AddForce(transform.up * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        // rotating left
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        // rotating right
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);
        }
    }

    void CheckBounds()
    {
        if(transform.position.x > XBounds)
        {
            transform.position = new Vector3(-XBounds, transform.position.y);
        }
        if (transform.position.x < -XBounds)
        {
            transform.position = new Vector3(XBounds, transform.position.y);
        }
        if (transform.position.y > YBounds)
        {
            transform.position = new Vector3(transform.position.x, -YBounds);
        }
        if (transform.position.y < -YBounds)
        {
            transform.position = new Vector3(transform.position.x, YBounds);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject newBullet = Instantiate(Bullet, ShootPosition.position, ShootPosition.rotation); // spawn the bullet at shootpoint
            Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(ShootPosition.up * bulletForce, ForceMode2D.Impulse); // apply some force to it
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Health--;
            if(Health <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
