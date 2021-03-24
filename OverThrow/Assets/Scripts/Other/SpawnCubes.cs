using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [Header("Balls Instantiate")]
    public Transform ballSpawn;
    public GameObject[] balls;

    public int numInt;

    public bool spawnCubes = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.isStart)
        {
            if (spawnCubes)
            {
                numInt = Random.Range(0, balls.Length);

                GameObject nextBall = Instantiate(balls[numInt], ballSpawn.position, ballSpawn.rotation);

                spawnCubes = false;
            }
        }
    }
}
