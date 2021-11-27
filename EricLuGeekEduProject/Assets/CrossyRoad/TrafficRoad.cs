using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficRoad : MonoBehaviour
{
    public int Direction; // the road direction
    public GameObject[] Cars; // list of our cars
    public float Timer;
    public float SpawnCarTime;
    public Transform CarSpawnPosition;
    int randomCar;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCarTime = Random.Range(5.5f, 10.5f);
        randomCar = Random.Range(0, Cars.Length);
        if(randomCar == 2) // if the random car is the truck
        {
            SpawnCarTime = Random.Range(10.5f, 12.5f); ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= SpawnCarTime)
        {
            GameObject newCar = Instantiate(Cars[randomCar], CarSpawnPosition.position, Quaternion.identity);
            newCar.GetComponent<CarBehaviour>().Direction = Direction;
            //newCar.GetComponent<CarBehaviour>().MoveSpeed = Random.Range(0.2f, 2);
            Timer = 0;
        }
        Timer += Time.deltaTime;
    }
}
