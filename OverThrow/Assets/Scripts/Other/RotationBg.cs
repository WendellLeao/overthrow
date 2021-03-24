using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBg : MonoBehaviour {

    public float speedX;
    public float speedY;
    public float speedZ;

    void Start () {
		
	}
	
	void Update () {
        if (GameManager.isStart)
        {
            transform.Rotate(new Vector3(speedX, speedY, speedZ));
        } 
	}
}
