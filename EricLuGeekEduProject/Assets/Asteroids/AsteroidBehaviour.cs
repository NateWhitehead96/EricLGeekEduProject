using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public GameObject Asteroid; // the new smaller chunk
    public Rigidbody2D rb2d;
    public float size;
    public float moveSpeed;
    public int RotationDirection;

    public float XBounds;
    public float YBounds;
    // Start is called before the first frame update
    void Start()
    {
        RotationDirection = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, RotationDirection);
    }

    // Update is called once per frame
    void Update()
    {
        MoveRock();
        CheckBounds();
        transform.localScale = new Vector3(size, size, 1);
    }

    void MoveRock()
    {
        rb2d.AddForce(transform.up * moveSpeed * Time.deltaTime);
    }
    void CheckBounds()
    {
        if (transform.position.x > XBounds)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // give some score
            FindObjectOfType<ShipBehaviour>().score += 1;
            Destroy(collision.gameObject);
            if (size > 0.1)
            {
                GameObject Asteroid1 = Instantiate(Asteroid, transform.position, Quaternion.identity);
                Asteroid1.GetComponent<AsteroidBehaviour>().size = size - 0.1f;
                GameObject Asteroid2 = Instantiate(Asteroid, transform.position, Quaternion.identity);
                Asteroid2.GetComponent<AsteroidBehaviour>().size = size - 0.1f;
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}
