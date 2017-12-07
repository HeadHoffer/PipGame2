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

    public float speed;
    public int ScoreValue;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        HP = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }

        transform.Translate(Vector3.back * speed * Time.deltaTime);
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
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
        HP -= damage;
    }

    void Die()
    {
        Debug.Log("u kyssed asteroid");
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SpaceShip>().UpdateScore(ScoreValue);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
