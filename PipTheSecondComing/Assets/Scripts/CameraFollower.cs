using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public bool ignoreX;
    public bool ignoreY;
    public bool ignoreZ;

    public bool targetLossSlowdown = true;
    public float slowdownDivider = 4f;

    private Vector3 mMomentum;

    void Update()
    {
        if (!target && targetLossSlowdown)
        {
            var p = transform.position;
            p += mMomentum;
            transform.position = p;
            mMomentum = Vector3.Lerp(mMomentum, Vector3.zero, 1f / slowdownDivider);
            return;
        }
        else if (!target)
            return;

        var oldPos = transform.position;
        var pos = target.position + offset;
        if (ignoreX)
            pos.x = oldPos.x;
        if (ignoreY)
            pos.y = oldPos.y;
        if (ignoreZ)
            pos.z = oldPos.z;
        mMomentum = pos - transform.position;
        transform.position = pos;
    }
}