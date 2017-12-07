using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        hp = 100;
        speed = 8;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hp <= 0)
        {
            Die();
        }

        transform.Translate(Vector3.back * speed * Time.deltaTime);
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
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SpaceShip>().UpdateScore(10);
        Destroy(this.gameObject);
    }
}
