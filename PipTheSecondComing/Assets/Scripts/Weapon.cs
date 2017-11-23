using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public Vector3 bulletDirection = Vector3.forward;
    public float bulletSpeed = 10f;

    //public float normalPitch = 1f;
    //public float maxPitch = 1.25f;
    //public float pitchCooldownTime = 1f;

    //private AudioSource mAudio;

    private float mLastShotTime = 0f;

    void Start()
    {
        //mAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //if (Time.time - mLastShotTime >= pitchCooldownTime)
            //{
            //    mAudio.pitch = normalPitch;
            //}
            //else
            //{
            //    mAudio.pitch = normalPitch + (maxPitch - normalPitch) * (pitchCooldownTime - (Time.time - mLastShotTime));
            //}

            //mAudio.Play();

            var bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = bulletDirection * bulletSpeed;

            mLastShotTime = Time.time;
        }
    }
}
