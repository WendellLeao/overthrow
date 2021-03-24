using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLaser : MonoBehaviour
{
    public GameObject Laser;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hideScan"))
        {
            Laser.SetActive(false);
        }
    }
}
