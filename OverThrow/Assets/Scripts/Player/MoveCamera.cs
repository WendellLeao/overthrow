using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Rigidbody body;
    //Transform player;

    public GameObject BoostParticles;
    public GameObject PressShift;

    public bool isMenu;

    private float speed;
    public float speedBoosted;
    public float speedNoBosted;

    public bool isBoosted = false;

    public static int canTurn;
    public static int canTurnCam;

    public bool setMove = false;

    public bool isTurnRight = false;
    public bool isTurnLeft = false;
    public bool isTurnUp = true;

    public Transform middleRoadUp;
    public Transform[] middleRoadRight;
    public Transform[] middleRoadLeft;

    private int currentRight = 0;
    private int currentLeft = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        //FindObjectOfType<AudioManager>().Play("ThemeMusic");
    }

    private void Start()
    {
        canTurn = 0;
    }
    void Update()
    {
        if (isMenu && !GameManager.isStart)
        {
            body.velocity = new Vector3(0, 0, speed);
        }

        if (GameManager.isStart)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = speedBoosted;
                BoostParticles.SetActive(true);
                PressShift.SetActive(false);
                isBoosted = true;
            }
            else
            {
                speed = speedNoBosted;
                BoostParticles.SetActive(false);
                isBoosted = false;
            }

            if (isBoosted)
            {
                AudioManager.instance.Play("BoostAudio");
            }
        }  
    }

    private void FixedUpdate()
    {
        if (GameManager.isStart)
        {
            if (Gun.isWind)
            {
                speed = speedBoosted;
                BoostParticles.SetActive(false);
            }

            //The up
            if (isTurnUp)
            {
                body.velocity = new Vector3(0, 0, speed);
                transform.position = new Vector3(middleRoadUp.position.x, transform.position.y, transform.position.z);
                transform.eulerAngles = new Vector3(0, 90, 0);
            } 

            //Whit Up
            if (isTurnRight)
            {
                isTurnUp = false;
                isTurnLeft = false;

                if (canTurn == 1) //Valor recebido se ele vier do Up pro Right
                {
                    body.velocity = new Vector3(speed, 0, 0);
                    transform.position = new Vector3(transform.position.x, transform.position.y, middleRoadRight[currentRight].position.z);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 2)
                {
                    body.velocity = new Vector3(0, 0, speed);
                    transform.position = new Vector3(middleRoadRight[currentRight].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 3)
                {
                    body.velocity = new Vector3(0, 0, -speed);

                    transform.position = new Vector3(middleRoadRight[currentRight].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, -90, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 4)
                {
                    body.velocity = new Vector3(0, 0, speed);

                    transform.position = new Vector3(middleRoadRight[currentRight].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 5)
                {
                    body.velocity = new Vector3(speed,0, 0);

                    transform.position = new Vector3(transform.position.x, transform.position.y, middleRoadRight[currentRight].position.z);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 6)
                {
                    body.velocity = new Vector3(0, 0, -speed);

                    transform.position = new Vector3(middleRoadRight[currentRight].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, -90, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 7)
                {
                    body.velocity = new Vector3(-speed,0, 0);

                    transform.position = new Vector3(transform.position.x, transform.position.y, middleRoadRight[currentRight].position.z);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    canTurnCam = 0;
                }
            }

            if (isTurnLeft)
            {
                isTurnUp = false;
                isTurnRight = false;

                if (canTurn == 1) //Valor se ele veio do Up pro left
                {
                    body.velocity = new Vector3(-speed, 0, 0);
                    transform.position = new Vector3(transform.position.x, transform.position.y, middleRoadLeft[currentLeft].position.z);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 2) //Valor quando ele não vem do Up, já passou pelo right
                {
                    body.velocity = new Vector3(0, 0, speed);
                    transform.position = new Vector3(middleRoadLeft[currentLeft].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 3)
                {
                    body.velocity = new Vector3(-speed, 0, 0);

                    transform.position = new Vector3(transform.position.x, transform.position.y, middleRoadLeft[currentLeft].position.z);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 4)
                {
                    body.velocity = new Vector3(0, 0, speed);

                    transform.position = new Vector3(middleRoadLeft[currentLeft].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    canTurnCam = 0;
                }

                if (canTurn == 5)
                {
                    body.velocity = new Vector3(0, 0, speed);
                    transform.position = new Vector3(middleRoadLeft[currentLeft].position.x, transform.position.y, transform.position.z);
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    canTurnCam = 0;
                }
            }
        }

        else
        {
            body.velocity = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Move rights (DONE)
        if (other.gameObject.CompareTag("moveRight") && isTurnUp)
        {
            canTurn = 1;
            canTurnCam = 1;
            isTurnRight = true;
            isTurnLeft = false;
        }

        if (other.gameObject.CompareTag("moveRight2"))
        {
            canTurn = 2;
            canTurnCam = 1;
            isTurnRight = true;
            isTurnLeft = false;
        }

        if (other.gameObject.CompareTag("moveRight3"))
        {
            canTurn = 3;
            canTurnCam = 1;
            isTurnRight = true;
            isTurnLeft = false;
        }

        if (other.gameObject.CompareTag("moveRight4"))
        {
            canTurn = 4;
            canTurnCam = 1;
            isTurnRight = true;
            isTurnLeft = false;
        }

        if (other.gameObject.CompareTag("moveRight5"))
        {
            canTurn = 5;
            canTurnCam = 1;
            currentRight = 1;
            isTurnRight = true;
            isTurnLeft = false;
        }

        if (other.gameObject.CompareTag("moveRight6"))
        {
            canTurn = 6;
            canTurnCam = 1;
            currentRight = 1;
            isTurnRight = true;
            isTurnLeft = false;
        }

        if (other.gameObject.CompareTag("moveRight7"))
        {
            canTurn = 7;
            canTurnCam = 1;
            currentRight = 2;
            isTurnRight = true;
            isTurnLeft = false;
        }

        //Move lefts
        if (other.gameObject.CompareTag("moveLeft") && isTurnUp)
        {
            canTurn = 1;
            currentLeft = 0;
            isTurnLeft = true;
            isTurnRight = false;
        }

        if (other.gameObject.CompareTag("moveLeft") && !isTurnUp)
        {
            canTurn = 2;
            currentLeft = 0;
            isTurnLeft = true;
            isTurnRight = false;
        }

        if (other.gameObject.CompareTag("moveLeft2"))
        {
            canTurn = 2;
            currentLeft = 1;
            isTurnLeft = true;
            isTurnRight = false;
        }

        if (other.gameObject.CompareTag("moveLeft3"))
        {
            canTurn = 3;
            currentLeft = 1;
            isTurnLeft = true;
            isTurnRight = false;
        }

        if (other.gameObject.CompareTag("moveLeft4"))
        {
            canTurn = 4;
            currentLeft = 3;
            isTurnLeft = true;
            isTurnRight = false;
        }

        if (other.gameObject.CompareTag("moveLeft5"))
        {
            canTurn = 5;
            currentLeft = 1;
            isTurnLeft = true;
            isTurnRight = false;
        }
    }

}

