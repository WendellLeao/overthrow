using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public static bool isVerify = false;
    public bool wasFloorVerify = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorVerify"))
        {
            wasFloorVerify = true;
        }

        if (collision.gameObject.CompareTag("ground") && !wasFloorVerify)
        {
            isVerify = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scanBar") && isVerify)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("limitFall"))
        {
            Destroy(gameObject);
        }

        /*if (other.gameObject.CompareTag("tnt"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(100, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }   ventilador mecanica     */
    }
}
