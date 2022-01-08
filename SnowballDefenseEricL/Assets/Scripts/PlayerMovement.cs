using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float bounds; // top and bottom boundary
    public float moveSpeed;

    public ShootSnowball shoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && transform.position.y < bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) && transform.position.y > -bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            PickupScript pickup = collision.gameObject.GetComponent<PickupScript>();
            if(pickup.type == Type.IncreaseShootSpeed)
            {
                shoot.shootSpeed -= 0.1f;
            }
            if(pickup.type == Type.IncreaseSnowballSize)
            {
                shoot.snowballSize += 0.1f;
            }
            if(pickup.type == Type.AddHealth)
            {
                ScoringSystem.Lives++;
            }
            Destroy(collision.gameObject);
        }
    }
}
