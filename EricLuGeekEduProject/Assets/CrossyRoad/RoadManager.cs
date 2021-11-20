using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] Roads; // an array of the road types
    public List<GameObject> CurrentRoads = new List<GameObject>(); // a list of all the roads we create
    public Vector3 LastRoadPosition; // the last position of our road
    public int NumStartingRoads; // how many roads the game will start with
    // Start is called before the first frame update
    void Start()
    {
        GenerateRoads();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateRoads()
    {
        for (int i = 0; i < NumStartingRoads; i++)
        {
            SpawnRoad();
        }
    }

    public void SpawnRoad()
    {
        int randomRoad = Random.Range(0, Roads.Length);
        CurrentRoads.Add(Instantiate(Roads[randomRoad], LastRoadPosition, Quaternion.identity));
        LastRoadPosition += Vector3.forward;
    }

}
