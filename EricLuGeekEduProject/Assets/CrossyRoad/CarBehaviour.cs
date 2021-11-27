using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public int Direction; // this will tell the car what direction to go in
    public float MoveSpeed; // how fast the car will travel
    public float Bounds; // this will tell the car when it's off the road and should delete itself
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }

        transform.position = new Vector3(transform.position.x + Direction * (MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z); // this will be its movement
        if(transform.position.x > Bounds && Direction == 1)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < -Bounds && Direction == -1)
        {
            Destroy(gameObject);
        }
    }
}
