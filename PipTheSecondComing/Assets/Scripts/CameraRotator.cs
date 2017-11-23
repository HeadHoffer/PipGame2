using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour
{
    public float xAngleMultiplier = 1f;
    public float yAngleMultiplier = 1f;

    public Transform target;

    void Update()
    {
        if (!target) return;

        var diff = (Vector2)(target.position - transform.position);
        var xAngle = diff.y * -xAngleMultiplier;
        var yAngle = diff.x * yAngleMultiplier;
        transform.eulerAngles = new Vector3(xAngle, yAngle, 0);
    }
}