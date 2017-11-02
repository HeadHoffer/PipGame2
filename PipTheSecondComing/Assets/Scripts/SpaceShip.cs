using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float speed;
    private float _originalSpeed; //jos halutaan muokata speediä esim boosteilla niin tarvitaan tämä palauttamista varten
 
    void Start()
    {
        _originalSpeed = speed;
    }
	
	void Update ()
    {
        Move();
    }

    private void Move()
    {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }
}
