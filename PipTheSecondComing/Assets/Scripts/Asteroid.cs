using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int _hp;

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public int dmg;

    public float speed;
    public float rotateSpeed;
    public int ScoreValue;
    public GameObject explosion;

    private float _trueSpeedX;
    private float _trueSpeedY;
    private float _trueSpeedZ;
    
    void Start()
    {
        HP = 150;

        _trueSpeedZ = Random.Range(rotateSpeed, 0 - rotateSpeed);
        _trueSpeedX = Random.Range(rotateSpeed, 0 - rotateSpeed);
        _trueSpeedY = Random.Range(rotateSpeed, 0 - rotateSpeed);
    }
    
    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }

        if (_trueSpeedZ == 0 && _trueSpeedX == 0 && _trueSpeedY == 0)
        { transform.Rotate(rotateSpeed, rotateSpeed, 0 - rotateSpeed, Space.World); }
        else
        { transform.Rotate(_trueSpeedZ, _trueSpeedX, _trueSpeedY, Space.World); }

        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
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
        Debug.Log("u kyssed asteroid");
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().UpdateScore(ScoreValue);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
