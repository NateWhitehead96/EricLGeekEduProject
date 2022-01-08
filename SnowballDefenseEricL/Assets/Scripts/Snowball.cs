using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Vector3 MoveToPosition; // this will be a position that the snowball will move to
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size, size, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveToPosition * Time.deltaTime); // this is the snowball movement

        if(transform.position.x > 12 || transform.position.y > 6 || transform.position.y < -6) // bounds check
        {
            Destroy(gameObject);
        }
    }
}
