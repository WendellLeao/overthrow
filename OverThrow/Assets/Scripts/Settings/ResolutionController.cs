using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionController : MonoBehaviour
{
    public void Resolution01()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolution02()
    {
        Screen.SetResolution(1600, 900, true);
    }

    public void Resolution03()
    {
        Screen.SetResolution(1440, 900, true);
    }

    public void Resolution04()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void Resolution05()
    {
        Screen.SetResolution(800, 600, true);
    }
}
