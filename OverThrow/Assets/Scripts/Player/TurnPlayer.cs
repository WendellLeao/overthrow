using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    public static bool isTurn = false;
    public static int canTurn = 1;
    void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && canTurn == 1)
        {
            transform.Rotate(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            isTurn = true;
            canTurn = 0;
        }*/
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "turn")
        {
            isTurn = true;
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }
    }
}
