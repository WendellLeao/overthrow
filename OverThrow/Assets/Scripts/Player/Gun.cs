using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    [Header("Initial Variables")]
    Animator anim;
    Transform player;

    public Transform spawnBalls;
    public GameObject[] balls;
    public Camera fpsCam;

    public GameObject Laser;
    
    [Header("Shoot Variables")]
    private float nextTimeToFire = 0f;
    public float fireRate;
    public float force;

    public int quantBalls;

    private int minBalls = 0;
    private int maxBalls;
    private int numInt;

    [Header("HUD")]
    //public GameObject ShowBallsText;
    //public GameObject SingleShowBallsText;

    public Text quantBallsText;

    //others
    public static bool turnLeft;
    public static bool turnRight;
    public static bool noTurn;

    private int canTurn = 0;

    public float turnSpeed;

    public static bool hideLaser = false;
    public static bool isWind = false;

    public GameObject EndGame;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Start()
    {
        quantBallsText.text = quantBalls.ToString();
        noTurn = true;
        turnRight = false;
        turnLeft = false;

        isWind = false;
    }
    private void Update()
    {
        if (GameManager.isStart)
        {
            noTurn = true;

            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && quantBalls != 0)
            {
                AudioManager.instance.Play("ShotAudio");
                nextTimeToFire = Time.time + 1f / fireRate;
                quantBalls--;
                quantBallsText.text = quantBalls.ToString();
                Shoot();
            }

            if (turnLeft)
            {
                noTurn = false;
            }

            if (turnRight)
            {
                turnLeft = false;
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))//range
        {
            //Debug.Log(hit.transform.name);
            var projectile = Instantiate(balls[numInt], spawnBalls.transform.position, Quaternion.identity);
            numInt = Random.Range(0, balls.Length);

            projectile.transform.LookAt(hit.point);

            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * force;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("turnLeft") && !turnRight)
        {
            turnLeft = true;
            RotateCam.canTurnCam += 1;

            canTurn = 1;

            if (canTurn == 1)
            {
                transform.Rotate(0, -90, 0);
                canTurn = 0;
            }
        }

        if (other.gameObject.CompareTag("turnRight") && !turnLeft)
        {
            turnRight = true;
            RotateCam.canTurnCam += 1;

            canTurn = 1;

            if (canTurn == 1)
            {
                transform.Rotate(0, +90, 0);
                canTurn = 0;
            }
        }

        if (other.gameObject.CompareTag("turnLeft") && turnRight)
        {
            noTurn = true;
            turnLeft = false;
            turnRight = false;
            RotateCam.canTurnCam += 1;

            canTurn = 1;

            if (canTurn == 1)
            {
                transform.Rotate(0, -90, 0);
                canTurn = 0;
            }
        }

        if (other.gameObject.CompareTag("turnRight") && turnLeft)
        {
            noTurn = true;
            turnLeft = false;
            turnRight = false;

            RotateCam.canTurnCam += 1;

            canTurn = 1;

            if (canTurn == 1)
            {
                transform.Rotate(0, +90, 0);
                canTurn = 0;
            }
        }

        /*if (other.gameObject.CompareTag("noTurn") && turnLeft)
        {
            noTurn = true;
            turnRight = false;
            turnLeft = false;

            RotateCam.canTurnCam += 1;

            canTurn = 1;

            if (canTurn == 1)
            {
                transform.Rotate(0, +90, 0);
                canTurn = 0;
            }
        }*/

        if (other.gameObject.CompareTag("endLine"))
        {
            GameManager.isWin = true;
            AudioManager.instance.Play("Magical");

            if (LevelManager.isIsRunStars)
            {
                GameManager.quantStars =+ 3;
            }
        }

        if (other.gameObject.CompareTag("endLineBoss"))
        {
            if (ScanBar.score >= Cubes.maxCubes)
            {
                AudioManager.instance.Play("Magical");
                EndGame.SetActive(true);
                GameManager.isStart = false;
            }
            else
            {
                Cubes.isLoser = true;
            }
        }

        if (other.gameObject.CompareTag("hideLaser"))
        {
            hideLaser = true;
        }

        if (other.gameObject.CompareTag("wind"))
        {
            isWind = true;
        }

        //More balls
        if (other.gameObject.CompareTag("more1ball"))
        {
            quantBalls += 1;
            quantBallsText.text = quantBalls.ToString();
        }

        if (other.gameObject.CompareTag("more2ball"))
        {
            quantBalls += 2;
            quantBallsText.text = quantBalls.ToString();
        }

        if (other.gameObject.CompareTag("SmashCube"))
        {
            Cubes.isLoser = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("hideLaser"))
        {
            Laser.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hideLaser"))
        {
            Laser.SetActive(true);
            hideLaser = false;
        }

        if (other.gameObject.CompareTag("wind"))
        {
            isWind = false;
        }
    }
}
