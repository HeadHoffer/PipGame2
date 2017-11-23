

using UnityEngine;
using System.Collections;

//this code will be ebin

public class SpaceShip : MonoBehaviour
{
    public float forwardSpeed;
    public float steeringSpeed;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public float movementSmoothing = 4f;

    private Vector2 mTargetPosition;

    private Vector2 mMovementDirection;

    public Vector2 MovementDirection
    {
        get { return mMovementDirection; }
    }

    void Awake()
    {
        minX = -8.3f;
        maxX = 8.3f;

        minY = -3.9f;
        maxY = 5.9f;
    }

    void Start()
    {
        mTargetPosition = (Vector2)transform.position;
    }

    void Update()
    {
        var pos = mTargetPosition;
        mMovementDirection = Vector2.zero;
        if (Input.GetKey("a"))
        {
            //left
            mMovementDirection.x = -1f;
            pos.x -= steeringSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            //Down
            mMovementDirection.y = -1f;
            pos.y -= steeringSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            //right
            mMovementDirection.x = 1f;
            pos.x += steeringSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            //Up
            mMovementDirection.y = 1f;
            pos.y += steeringSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        mTargetPosition = pos;

        var xyPos = Vector2.Lerp(transform.position, mTargetPosition, 1f / movementSmoothing);
        transform.position = new Vector3(xyPos.x, xyPos.y, transform.position.z);

        MoveForward();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpaceShip : MonoBehaviour
//{
//    public float speed;
//    private float _originalSpeed; //jos halutaan muokata speediä esim boosteilla niin tarvitaan tämä palauttamista varten
//    public float forwardSpeed;

//    void Start()
//    {
//        _originalSpeed = speed;
//        forwardSpeed = _originalSpeed;
//    }

//	void Update ()
//    {
//        Move();
//    }

//    private void Move()
//    {

//        if (Input.GetKey("w"))
//        {
//            transform.Translate(Vector3.forward * Time.deltaTime * speed);
//        }
//        if (Input.GetKey("a"))
//        {
//            transform.Translate(Vector3.left * Time.deltaTime * speed);
//        }
//        if (Input.GetKey("s"))
//        {
//            transform.Translate(Vector3.back * Time.deltaTime * speed);
//        }
//        if (Input.GetKey("d"))
//        {
//            transform.Translate(Vector3.right * Time.deltaTime * speed);
//        }

//    }
//}
