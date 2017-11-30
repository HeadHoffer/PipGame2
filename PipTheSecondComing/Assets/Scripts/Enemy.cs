using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy hp
    public int hp; 

	// Use this for initialization
	void Start ()
    {
        hp = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hp <= 0)
        {
            Die();
        }
	}

    // Check collision
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected: " + other.name);

        if (other.tag == "Bullet")
        {
            TakeDamage(100);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
    }

    void Die()
    {
        Debug.Log("u kyssed enemy");
        Destroy(this.gameObject);
    }
}
