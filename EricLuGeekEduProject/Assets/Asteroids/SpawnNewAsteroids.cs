using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewAsteroids : MonoBehaviour
{
    public GameObject Asteroid;
    public int oldScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<ShipBehaviour>().score >= oldScore + 12)
        {
            int randomX = Random.Range(-11, 12);
            int randomY = Random.Range(-5, 6);
            Instantiate(Asteroid, new Vector3(randomX, randomY, 1), Quaternion.identity);
            oldScore += 12;
        }
    }
}
