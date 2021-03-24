using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFollowCamera : MonoBehaviour
{
    public Transform camPos;
    void Start()
    {
        this.transform.SetParent(camPos);
    }
}
