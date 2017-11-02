using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float speed;
    Vector3 playerPos;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerPos = transform.position;

		if(Input.GetKeyDown("w"))
        {
            playerPos.z += speed ;
            transform.position = playerPos;
        }
	}
}
