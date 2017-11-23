using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyGameObject;

	private GameObject _player;
	private float _offset;
	private float _speed;
	private bool _canSpawn;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
		_offset = 20;
		_speed = 5;
		_canSpawn = true;
		Debug.Log ("hello t. enemy");
	}
	
	// Update is called once per frame
	void Update () {
		if (_canSpawn)
		{
			Vector3 spawnPos = _player.transform.position;
			spawnPos.z = transform.position.z + _offset;
			GameObject enemy = (GameObject)Instantiate (enemyGameObject, spawnPos, transform.rotation);
			enemy.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
			Debug.Log ("spawned enemy");
			_canSpawn = false;
		}
	}
}
