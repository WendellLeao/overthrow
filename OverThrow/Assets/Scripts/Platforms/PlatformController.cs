using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    protected Transform player;
    protected bool isMoving;

    public float distanceAttack;


    public bool isRight;
    public bool isLeft;

    public int canRotate = 1;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    protected float PlayerDistance()
    {
        return Vector3.Distance(player.position, transform.position);
    }
    protected virtual void Update()
    {
        float distance = PlayerDistance();
        isMoving = (distance <= distanceAttack);
    }
}
