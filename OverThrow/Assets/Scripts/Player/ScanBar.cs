using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScanBar : MonoBehaviour
{
    [Header("Victory")]
    //Material
    public Material LaserImpact;
    public Material ScanMaterial;
    public Material ExplodeLaser;

    public static bool isTrigger = false;

    public static int score = 0;
    //Text
    public Text scoreText;
    public Text scoreTextPanel;

    public GameObject scoreObject;

    public GameObject Hud;

    private void Start()
    {
        //scoreObject.SetActive(false);
        scoreObject.SetActive(true);

        score = 0;
    }
    void FixedUpdate()
    {
        if (GameManager.isStart)
        {
            //score = GameManager.lastMinScore; 

            if (isTrigger)
            {
                AudioManager.instance.Play("LaserSound");
                this.gameObject.GetComponent<MeshRenderer>().material = LaserImpact;

                isTrigger = false;
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material = ScanMaterial;
            }

            if (GameManager.isWin)
            {
                //scoreTextPanel.text = score.ToString();
                Hud.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balls") && Balls.isVerify)
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("balls") && Balls.isVerify)
        {
            isTrigger = false;
        }
    }
}
