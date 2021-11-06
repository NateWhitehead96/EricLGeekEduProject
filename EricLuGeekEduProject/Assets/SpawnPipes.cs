using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject Pipe; // a reference to the pipe prefab
    public float Timer; // the current time
    public float SpawnTime = 4; // the time to spawn a pipe

    public int Ybounds; // make sure we spawn the pipes within the screen
    public int oldScore; // this will keep track of a previous score

    // Update is called once per frame
    void Update()
    {
        if(Timer >= SpawnTime) // when our current time is greater than or equal to the spawn time
        {
            RandomSpawn();
            Instantiate(Pipe, transform.position, Quaternion.identity); // to spawn the pipe
            Timer = 0; // reset the timer
        }
        Timer += Time.deltaTime; // increment the timer with time
        MakePipesSpawnFaster();
    }

    void RandomSpawn()
    {
        int randomYValue = Random.Range(-Ybounds, Ybounds + 1); // making a random value from - y bounds to + y bounds
        transform.position = new Vector3(transform.position.x, randomYValue, transform.position.z); // set the new position to our current position
    }

    void MakePipesSpawnFaster()
    {
        if(FindObjectOfType<FlappyBird>().score >= oldScore + 10 && SpawnTime > 0.5) // when the player score is an old score plus what we need to get to the next difficulty make the oldscore the player score decrease spawn time
        {
            oldScore += 10;
            SpawnTime -= 0.5f;
        }
    }
}
