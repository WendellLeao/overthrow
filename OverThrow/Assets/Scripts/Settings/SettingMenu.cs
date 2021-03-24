using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public void SetSensitivity(float sensitivity)
    {
        RotateCam.sensibility = sensitivity;

        Debug.Log(sensitivity);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
