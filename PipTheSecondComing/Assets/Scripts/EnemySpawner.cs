using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyGameObject;

    public float timeBetweenSpawns;
    public float spawnRange;

    private GameObject _player;
	public float offset;
    private float _timer;
    
	void Start ()
    {
        timeBetweenSpawns = 3;
        spawnRange = 6;

        _player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update ()
    {
        // Spawn timer
        _timer += Time.deltaTime;
        if (_timer > timeBetweenSpawns)
        {
            if(_player)
            {
                SpawnEnemy();
            }
            _timer = 0.0f;
        }

        DestroyEnemies();
	}

    void SpawnEnemy()
    {
        // Create spawn position for enemy from player position
        Vector3 spawnPos = _player.transform.position;
        spawnPos.z = _player.transform.position.z + offset;

        // Need to add some weird offset to line up correctly
        spawnPos.y = -0.3f;

        // Random position for x-axis
        spawnPos.x = Random.Range(-spawnRange, spawnRange);

        // Instatiate game object and add a tag 
        GameObject enemy = (GameObject)Instantiate(enemyGameObject, spawnPos, transform.rotation);
        enemy.gameObject.tag = "Enemy";

        // Scale down
        enemy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        Debug.Log("spawned enemy");
    }

    // Destroy enemies if offscreen
    void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            if(_player)
            {
                if (enemy.transform.position.z < (_player.transform.position.z - 10.0f))
                    Destroy(enemy);
            }
        }
    }
}
