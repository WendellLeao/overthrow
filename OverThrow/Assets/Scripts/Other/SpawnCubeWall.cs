using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubeWall : MonoBehaviour
{
    public GameObject cubeWall;
    public Transform cubeWallSpawnPos;

    public bool canInstantiate = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnCubePlayer"))
        {
            canInstantiate = true;

            if (canInstantiate)
            {
                Instantiate(cubeWall, cubeWallSpawnPos.position, cubeWallSpawnPos.rotation);         
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnCubePlayer"))
        {
            canInstantiate = false;
            this.transform.Translate(new Vector3(0, 0, this.transform.position.z + 2));
        }
    }
}
