using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidGameObject;

    public float timeBetweenSpawns;
    public float spawnRange;

    private GameObject _player;
    public float offset;
    private float _timer;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("hello t. asteroid");
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn timer
        _timer += Time.deltaTime;
        if (_timer > timeBetweenSpawns)
        {
            SpawnAsteroid();
            _timer = 0.0f;
        }

        DestroyAsteroids();
    }

    void SpawnAsteroid()
    {
        // Create spawn position for enemy from player position
        Vector3 spawnPos = _player.transform.position;
        spawnPos.z = _player.transform.position.z + offset;

        // Need to add some weird offset to line up correctly
        spawnPos.y = -0.3f;

        // Random position for x-axis
        spawnPos.x = Random.Range(-spawnRange, spawnRange);

        // Instatiate game object and add a tag 
        GameObject asteroid = (GameObject)Instantiate(asteroidGameObject, spawnPos, transform.rotation);
        asteroid.gameObject.tag = "Asteroid";

        // Scale down
        float asteroidScale = Random.Range(70.0f, 200.0f);
        asteroid.transform.localScale = new Vector3(asteroidScale, asteroidScale, asteroidScale);
        Debug.Log("spawned asteroid");
    }

    // Destroy enemies if offscreen
    void DestroyAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid.transform.position.z < (_player.transform.position.z - 10.0f))
                Destroy(asteroid);
        }
    }
}
