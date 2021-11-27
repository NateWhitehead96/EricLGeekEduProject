using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpRoad : MonoBehaviour
{
    public Transform PlayerPosition;

    private void Start()
    {
        PlayerPosition = FindObjectOfType<PlayerScript>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPosition.position.z > transform.position.z + 10) // if player is 10 units ahead of the road, delete the road
        {
            Destroy(gameObject);
        }
    }
}
