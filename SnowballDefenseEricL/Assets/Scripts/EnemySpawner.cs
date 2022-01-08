using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float bounds;
    public GameObject[] SpawnedObject;
    public ParticleSystem Snowfall;

    public float timer;
    public float SpawnTime = 2;

    public int NumberOfEnemies; // how many enemies per wave
    public int maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfEnemies = 3;
        maxSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= SpawnTime && NumberOfEnemies > 0)
        {
            SpawnNextThing();
        }
        timer += Time.deltaTime; // add to our timer
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5);
        ScoringSystem.Wave++;
        NumberOfEnemies += ScoringSystem.Wave * 3;
        maxSpeed++;
        if(SpawnTime > 1)
        {
            SpawnTime -= 0.1f;
        }
    }

    public void SpawnNextThing()
    {
        int x = Random.Range(0, 11); // random number from 0 - 10
        float randomY = Random.Range(-bounds, bounds); // find a random y value
        if (x == 0)
        {
            Instantiate(SpawnedObject[1], new Vector3(transform.position.x, randomY), Quaternion.identity);
        }
        else
        {
            GameObject newEnemy = Instantiate(SpawnedObject[0], new Vector3(transform.position.x, randomY), Quaternion.identity); // spawn new enemy
            newEnemy.GetComponent<Enemy>().moveSpeed = Random.Range(1, maxSpeed); // apply random move speed
            NumberOfEnemies--;
            timer = 0;
            if (NumberOfEnemies <= 0)
            {
                StartCoroutine(NextWave());
            }
        }
    }
}
