

using UnityEngine;
using System.Collections;

//this code will be ebin

public class SpaceShip : MonoBehaviour
{
    public float forwardSpeed;
    public float steeringSpeed;
    private float _realSpeed;

    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;

    public float movementSmoothing = 4f;

    private Vector3 mTargetPosition;

    private Vector3 mMovementDirection;

    public Vector3 MovementDirection
    {
        get { return mMovementDirection; }
    }

    void Awake()
    {
        minX = -8.3f;
        maxX = 8.3f;

        minZ = -3.9f;
        maxZ = 5.9f;
    }

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * steeringSpeed * Time.deltaTime);
        }

        if(Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * steeringSpeed * Time.deltaTime);
        }

        MoveForward();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}