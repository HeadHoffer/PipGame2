
using UnityEngine;
using System.Collections;

public class TimedDestructor : MonoBehaviour
{
    public float time = 10f;

    private float mTimer;

    void Update()
    {
        mTimer += Time.deltaTime;
        if (mTimer >= time)
        {
            Destroy(gameObject);
        }
    }
}
