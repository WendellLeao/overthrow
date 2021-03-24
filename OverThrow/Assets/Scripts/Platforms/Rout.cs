using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rout : MonoBehaviour
{
    private Rigidbody body;
    public Transform camPos;

    public float speed;
    
    public Transform[] midlleUp;
    public Transform[] midlleDown;
    public Transform[] midlleRight;
    public Transform[] midlleLeft;

    private int up = 0;
    private int down = 0;
    private int right = 0;
    private int left = 0;

    private int currentUp = -1;
    private int currentDown = -1;
    private int currentRight = -1;
    private int currentLeft = -1;

    public static int canTurnUp = 0;
    public static int canTurnDown = 0;
    public static int canTurnRight = 0;
    public static int canTurnLeft = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (up == 1)
        {
            body.velocity = new Vector3(0,0,speed);
            transform.position = new Vector3(midlleUp[currentUp].position.x, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        else if (down == 1)
        {
            body.velocity = new Vector3(0, 0, -speed);
            transform.position = new Vector3(midlleDown[currentDown].position.x, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        else if (right == 1)
        {
            body.velocity = new Vector3(speed,0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, midlleRight[currentRight].position.z);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if (left == 1)
        {
            body.velocity = new Vector3(-speed, 0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, midlleLeft[currentLeft].position.z);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("up"))
        {
            up = 1;
            down = 0;
            right = 0;
            left = 0;

            canTurnUp = 1;

            if(canTurnUp == 1)
            {
                currentUp++;
                canTurnUp = 0;
            }
        }

        if (other.gameObject.CompareTag("down"))
        {
            down = 1;
            up = 0;
            right = 0;
            left = 0;

            canTurnDown = 1;

            if (canTurnDown == 1)
            {
                currentDown++;
                canTurnDown = 0;
            }
        }

        if (other.gameObject.CompareTag("right"))
        {
            right = 1;
            up = 0;
            down = 0;
            left = 0;

            canTurnRight = 1;

            if (canTurnRight == 1)
            {
                currentRight++;
                canTurnRight = 0;
            }
        }

        if (other.gameObject.CompareTag("left"))
        {
            left = 1;
            up = 0;
            down = 0;
            right = 0;

            canTurnLeft = 1;

            if (canTurnLeft == 1)
            {
                currentLeft++;
                canTurnLeft = 0;
            }
        }
    }
}
