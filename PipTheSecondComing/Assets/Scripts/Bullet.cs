using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int DMG;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "BulletDestroyer")
            Destroy(this.gameObject);
    }
}
