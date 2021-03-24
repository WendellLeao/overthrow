using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject greenCube;
    public Transform spawnBullet;

    public GameObject particle;
    public Transform spawnParticle;

    private float time = 0f;
    public float timer;
    void Update()
    {
        if (GameManager.isStart)
        {
            time += Time.deltaTime;

            if (time >= timer)
            {
                time = 0f;

                AudioManager.instance.Play("CannonAudio");
                GameObject cloneBullet = Instantiate(greenCube, spawnBullet.position, spawnBullet.rotation);

                Cubes.qtdCubes -= 100;

                GameObject particleClone = Instantiate(particle, spawnBullet.position, spawnBullet.rotation);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("balls"))
        {
            AudioManager.instance.Play("CubeAudio");
        }
    }
}
