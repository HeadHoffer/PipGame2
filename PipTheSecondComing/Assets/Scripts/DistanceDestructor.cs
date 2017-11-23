using UnityEngine;
using System.Collections;

public class DistanceDestructor : MonoBehaviour
{
    public float distance = 30f;
    public Transform target;

    void Update()
    {
        if (!target) return;

        if (Vector3.Distance(transform.position, target.position) >= distance)
            Destroy(gameObject);
    }
}