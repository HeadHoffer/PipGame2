﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _hp;

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public float speed;

    public int scoreValue;

    public GameObject bulletPrefab;
    public GameObject explosion;
    public Vector3 bulletDirection = Vector3.forward;
    public float bulletSpeed;
    public float timeBetweenShots;

    private float _shotTimer;
    
    void Start ()
    {
        HP = 100;
        speed = 8;
        bulletSpeed = 10.0f;
        timeBetweenShots = 2.0f;
    }
	
	void Update ()
    {
        if (HP <= 0)
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
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            TakeDamage(other.GetComponent<Bullet>().DMG);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public void Die()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().UpdateScore(scoreValue);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
