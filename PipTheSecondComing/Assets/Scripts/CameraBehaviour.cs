﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    private GameObject mainCamera;
    public GameObject spaceship;
    public float forwardSpeed;
    
	void Start ()
    {
        mainCamera = Camera.main.transform.gameObject;
        forwardSpeed = spaceship.GetComponent<SpaceShip>().forwardSpeed;
    }
	
	void Update ()
    {
        MoveForward();
	}

    void MoveForward()
    {
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);
    }
}