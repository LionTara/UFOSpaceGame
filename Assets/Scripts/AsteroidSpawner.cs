using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //public Asteroid asteroidScript;  // Add this line

    public GameObject asteroid;
    public float size = 100;
    public int countPerWave = 10;
    public float waveDelay = 0.5f;
    //public int totalAsteroids = 100;  // Total number of asteroids to spawn
    //private int asteroidsSpawned = 0;  // Number of asteroids spawned so far


    // Start is called before the first frame update
    void Start()
    {       
        StartCoroutine(SpawnAsteroids());   
    }

    // Update is called once per frame
    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            for( int i = 0; i < countPerWave;  i++ )
            {
                Vector3 pos = transform.position;
                float hor = Random.Range(-size, size);
                float ver = Random.Range(-size, size);
                Vector3 random = new Vector3(0, ver, hor);
                pos += random;
                Instantiate(asteroid, pos, transform.rotation);
                //asteroidsSpawned++;  // Increment the number of asteroids spawned

            }

            yield return new WaitForSeconds(waveDelay);
        }

        
    }
}
