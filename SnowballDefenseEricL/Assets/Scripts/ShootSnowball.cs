using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click input
        {
            GameObject newSnowball = Instantiate(ball, transform.position, Quaternion.identity); // spawing the ball of snow
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position
            Vector3 shootDirection = mousePosition - transform.position; // the new direction vector between our mouse and player
            newSnowball.GetComponent<Snowball>().MoveToPosition = new Vector3(shootDirection.x, shootDirection.y); // applying that direction vector to our snowball
        }
    }
}
