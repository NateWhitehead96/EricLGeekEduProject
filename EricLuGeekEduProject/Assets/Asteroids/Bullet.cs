using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float xbounds = 11;
    public float ybounds = 5.2f;

    // Update is called once per frame
    void Update()
    {
        

        if(transform.position.x > xbounds || transform.position.x < -xbounds)
        {
            Destroy(gameObject);
        }
        if(transform.position.y > ybounds || transform.position.y < -ybounds)
        {
            Destroy(gameObject);
        }
    }
}
