using UnityEngine;
using System.Collections;

public class ConstantMotion : MonoBehaviour
{
    public Vector3 movementPerSecond = Vector3.forward;
    public Vector3 rotationPerSecond = Vector3.zero;

    void Update()
    {
        var pos = transform.position;
        pos += movementPerSecond * Time.deltaTime;
        transform.position = pos;
        var ang = transform.eulerAngles;
        ang += rotationPerSecond * Time.deltaTime;
        transform.eulerAngles = ang;
    }
}