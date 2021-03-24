using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashCube : MonoBehaviour
{
    public float maxDistanceVertical;
    public float speedSmash;
    void Update()
    {
        if (GameManager.isStart)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speedSmash, maxDistanceVertical), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
