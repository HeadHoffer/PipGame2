using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public Vector3 bulletDirection = Vector3.forward;
    public float bulletSpeed = 10f;

    private float mLastShotTime = 0f;

    public int bulletDmg;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
            bullet.GetComponent<Bullet>().DMG = bulletDmg;
            bullet.GetComponent<Rigidbody>().velocity = bulletDirection * bulletSpeed;

            mLastShotTime = Time.time;
        }
    }
}
