using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cubes : MonoBehaviour
{
    [Header("Cube Selector")]
    public bool isRed;
    public bool isBlue;

    public bool isGreenRight;
    public bool isGreenLeft;
    public bool isGreenDown;
    public bool isGreenUp;

    public bool CubeMoreBalls;
    [Header("Verification")]
    //Cubes Types
    private bool isSafeCube = false;
    private bool isVerify = false;

    [Header("Controllers")]
    public static bool isLoser = false;

    [Header("Others")]
    //Materials
    public Material RedOff;
    public Material BlueOff;
    public Material GreenOff;

    public GameObject PointLight;

    public static bool speedChange = false;
    public static bool isBrokenScreen = false;
    public static bool isExplodeLaser = false;

    public static bool moreBalls;
    public static int canMoreBalls;

    public float forceCannon;

    public static bool touchPlayer;
    public int canTouch = 0;

    public static bool isShake;

    public int canAudioCube = 0;

    [Header("Calculator")]
    public static int cubesQuant = 0;
    public static int maxCubes = 0;
    public static int qtdCubes = 0;

    private int canCount = 1;
    private int canScore = 1;
    private void Start()
    {
        maxCubes++;
        cubesQuant = 0;

        canMoreBalls = 0;

        isShake = false;

        if (isGreenRight)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(forceCannon * Time.deltaTime, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        else if (isGreenLeft)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-forceCannon * Time.deltaTime, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        else if (isGreenDown)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, -forceCannon * Time.deltaTime);
        }

        else if (isGreenUp)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, forceCannon * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.isStart)
        {
            //Time definition
            if (speedChange)
            {
                speedChange = false;
            }

            if (isSafeCube)
            {
                PointLight.SetActive(false);
            }

            if(canCount == 1)
            {
                qtdCubes += 100;
                canCount = 0;
            }
        }
        else
        {
            maxCubes = 0;
            cubesQuant = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Turn SafeCube
        if (collision.gameObject.CompareTag("ground") && !isVerify)
        {
            isSafeCube = true;

            if (isRed)
            {
                this.gameObject.GetComponent<MeshRenderer>().material = RedOff;
            }

            if (isBlue)
            {
                this.gameObject.GetComponent<MeshRenderer>().material = BlueOff;
            }

            if (isGreenRight || isGreenLeft)
            {
                this.gameObject.GetComponent<MeshRenderer>().material = GreenOff;
            }
        }


        if (collision.gameObject.CompareTag("balls") && CubeMoreBalls)
        {
            moreBalls = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("balls"))
        {
            AudioManager.instance.Play("CubeAudio");
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            canAudioCube = 1;

            if(canAudioCube == 1)
            {
                AudioManager.instance.Play("CubeAudio");
                canAudioCube = 0;
            }
        }

        if (collision.gameObject.CompareTag("Player") && !isSafeCube)
        {
            /*canTouch = 1;

            if(canTouch == 1)
            {
                LevelManager.hp--;
                canTouch = 0;
            }*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scanBar") && isSafeCube || other.gameObject.CompareTag("limitFall") || other.gameObject.CompareTag("endLine") || other.gameObject.CompareTag("floorVerify") && isSafeCube)
        {
            if(!isGreenUp && !isGreenRight && !isGreenDown && !isGreenLeft)
            {
                if (canScore == 1)
                {
                    ScanBar.score += 100;
                    Destroy(gameObject);
                    canScore = 0;
                }
            }
        }

        if (other.gameObject.CompareTag("scanBar") && isSafeCube)
        {
            ScanBar.isTrigger = true;
        }

        if (other.gameObject.CompareTag("scanBar") && !isSafeCube)
        {
            ScanBar.isTrigger = true;
        }

        if (other.gameObject.CompareTag("floorVerify") && !isSafeCube && !LevelManager.isIsLvl15)
        {
            //isShake = true;
            isLoser = true;
        }

        if (other.gameObject.CompareTag("floorVerify") && !isSafeCube && LevelManager.isIsLvl15)
        {
            //isShake = true;
            canTouch = 1;

            if (canTouch == 1)
            {
                LevelManager.hp--;
                canTouch = 0;
            }
        }

        if (other.gameObject.CompareTag("floorVerify"))
        {
            isVerify = true;
        }

        if (other.gameObject.CompareTag("hideLaser") && Gun.hideLaser)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("scanBar") && isSafeCube)
        {
            ScanBar.isTrigger = false;
        }

        if (other.gameObject.CompareTag("scanBar") && !isSafeCube)
        {
            ScanBar.isTrigger = false;
        }
    }
}
