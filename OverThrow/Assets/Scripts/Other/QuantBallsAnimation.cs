using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantBallsAnimation : MonoBehaviour
{
    public GameObject QuantBallsText;

    private void Start()
    {
        //GetComponent<Animator>().SetTrigger("showQuant");
    }
    void FixedUpdate()
    {
        if (GameManager.isStart)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<Animator>().SetTrigger("showQuant");
            }

            if (Cubes.moreBalls)
            {
                GetComponent<Animator>().SetTrigger("showQuant");
            }
        }       
    }
}
