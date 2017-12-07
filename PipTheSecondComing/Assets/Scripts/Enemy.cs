using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float speed;

    public GameObject bulletPrefab;
    public Vector3 bulletDirection = Vector3.forward;
    public float bulletSpeed;
    public float timeBetweenShots;

    private float _shotTimer;

    // Use this for initialization
    void Start ()
    {
        hp = 100;
        speed = 8;
        bulletSpeed = 10.0f;
        timeBetweenShots = 2.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hp <= 0)
        {
            Die();
        }

        transform.Translate(Vector3.back * speed * Time.deltaTime);

        _shotTimer += Time.deltaTime;
        if (_shotTimer > 2.0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = bulletDirection * bulletSpeed;

            _shotTimer = 0.0f;
        }  
    }

    // Check collision
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected: " + other.name);

        if (other.tag == "Bullet")
        {
            TakeDamage(30);
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
