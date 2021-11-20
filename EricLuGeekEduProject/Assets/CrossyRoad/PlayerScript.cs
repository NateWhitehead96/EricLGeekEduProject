using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
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
        //if (Input.GetKeyDown("w"))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKeyDown("a"))
        //{
        //    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKeyDown("d"))
        //{
        //    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //}

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + xDirection * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z + zDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RoadCross"))
        {
            FindObjectOfType<RoadManager>().SpawnRoad();
        }
    }
}
