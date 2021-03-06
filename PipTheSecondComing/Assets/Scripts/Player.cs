﻿

using UnityEngine;
using System.Collections;

//this code will be ebin

public class Player : MonoBehaviour
{
    public float steeringSpeed;
    
    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    public float movementSmoothing = 4f;

    public GameObject explosion;

    private Vector3 _targetPosition;
    private Vector3 _nullPos;

    private Vector3 _movementDirection;

    public Vector3 MovementDirection
    {
        get { return _movementDirection; }
    }

    private int _playerScore = 0;

    public int PlayerScore
    {
        get { return _playerScore; }
    }

    private int _playerHP;
    public bool isDead = false;

    public int PlayerHP
    {
        get { return _playerHP; }
        set { _playerHP = value; }
    }

    public GameObject Camera;
    public GameObject[] DeathText;

    void Awake()
    {
        maxX = 6.5f;
        minX = -6.5f;
        maxZ = 15.0f;
        minZ = -15.0f;
    }

    void Start()
    {
        if (!Camera)
            Camera = GameObject.FindGameObjectWithTag("MainCamera");
        
        _targetPosition = transform.position;

        PlayerHP = 100;
    }

    void Update()
    {
        _nullPos = Camera.transform.position;
        var pos = _targetPosition;
        var rotation = transform.rotation;
        _movementDirection = Vector3.zero;

        if(Input.GetAxisRaw("Vertical") > 0)
        {
            //UP
            _movementDirection.x = -1f;
            pos.x -= steeringSpeed * Time.deltaTime;
        }

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            //LEFT
            _movementDirection.z = -1f;
            pos.z -= steeringSpeed * Time.deltaTime;
        }

        if(Input.GetAxisRaw("Vertical") < 0)
        {
            //DOWN
            _movementDirection.x = 1f;
            pos.x += steeringSpeed * Time.deltaTime;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            //RIGHT
            _movementDirection.z = 1f;
            pos.z += steeringSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Lerp(rotation, Quaternion.Euler(0, 0, _movementDirection.x * -20), Time.deltaTime * steeringSpeed);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        _targetPosition = pos;

        var xzPos = Vector3.Lerp(transform.position, _targetPosition, 1f / movementSmoothing);
        transform.position = new Vector3(xzPos.x, transform.position.y, xzPos.z);
    }

    public void UpdateScore(int value)
    {
        _playerScore += value;
    }

    public void TakeDamage(int damage)
    {
        PlayerHP -= damage;
        if(PlayerHP <= 0)
        {
            PlayerHP = 0;
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "EnemyBullet":
                TakeDamage(other.GetComponent<Bullet>().DMG);
                Destroy(other.gameObject);
                break;
            case "Enemy":
                TakeDamage(30);
                other.GetComponent<Enemy>().Die();
                break;
            case "Asteroid":
                TakeDamage(other.GetComponent<Asteroid>().dmg);
                other.GetComponent<Asteroid>().Die();
                break;
        }
    }

    public void Die()
    {
        isDead = true;
        for(int i = 0; i < DeathText.Length; i++)
        {
            if (DeathText[i])
                DeathText[i].SetActive(true);
        }
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}