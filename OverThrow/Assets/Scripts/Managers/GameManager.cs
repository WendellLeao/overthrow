using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    public static bool isStart = false;
    public static bool isWin = false;
    public static bool isMenu = true;

    [Header("Hud")]
    public Text panelScoreLoser;
    public Text quantStarsText;
    public Text panelScoreWin;
    public Text maxScoreText;
    public Text scoreText;

    public Text lvlNumText;
    public Text nextLvlText;

    public static int currentLvl = 1;
    public static int nextLvlNum;

    [Header("Score")]
    public static int canChangeValue;
    public static int badScore = 250;

    private int minScore;
    private int maxScore;

    [Header("Sounds")]
    AudioSource sound;

    [Header("Others GameObjects")]
    public GameObject loserPanel;
    public GameObject startPanel;
    public GameObject victoryPanel;
    public GameObject laserParticles;
    public GameObject worldParticles;
    public GameObject Laser;
    public GameObject Crosshair;
    public GameObject MenuTowers;

    //public GameObject ImpactParticles;

    [Header("Stars")]
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    private bool isStar1;
    private bool isStar2;
    private bool isStar3;

    public int canGiveStars;
    public static int quantStars;

    [Header("World Selector")]
    private bool secondWorld = false;
    private bool thirdWorld = false;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    void Start()
    {
        //Initial
        //isStart = true;
        isWin = false;

        //Start Value
        ScanBar.score = 0;
        Cubes.qtdCubes = 0;

        //Classes controller
        Cubes.isLoser = false;
        Cubes.speedChange = false;
        Cubes.cubesQuant = 0;

        //Panels and GameObjects
        victoryPanel.SetActive(false);
        loserPanel.SetActive(false);

        //HUD
        maxScoreText.text = maxScore.ToString();
        quantStarsText.text = quantStars.ToString();

        //Others
        Time.timeScale = 1;

        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);

        //lvl hud
        nextLvlNum = currentLvl + 1;

    }
    void FixedUpdate()
    {
        quantStarsText.text = quantStars.ToString();

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            quantStars = 25;
        }*/

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.isStart = true;
        }*/

        /*if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Lvl20");
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            isStart = false;
        }

        if (isStart)
        {
            //progress bar 
            lvlNumText.text = currentLvl.ToString();
            nextLvlText.text = nextLvlNum.ToString();

            //Cursos visibility
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            //HUD & Scores
            maxScore = Cubes.qtdCubes;
            maxScoreText.text = maxScore.ToString();
            minScore = Cubes.qtdCubes / 2;
            scoreText.text = ScanBar.score.ToString();

            if (Cubes.isLoser)
            {
                AudioManager.instance.Play("DeathAudio");
                Lost();
            }

            if (isWin)
            {
                Win();
                currentLvl += 1;
            }
            else
            {
                victoryPanel.SetActive(false);
            }

            if (ScanBar.score > 0 && ScanBar.score <= minScore) //= badScore
            {
                Star1.SetActive(true);
                quantStarsText.text = quantStars.ToString();
                isStar1 = true;
            }

            if (ScanBar.score >= minScore && ScanBar.score > 0)
            {
                Star2.SetActive(true);
                quantStarsText.text = quantStars.ToString();
                isStar2 = true;
            }

            if (ScanBar.score >= maxScore && ScanBar.score >= minScore && ScanBar.score > 0)
            {
                Star3.SetActive(true);
                quantStarsText.text = quantStars.ToString();
                isStar1 = true;
            }

            if (LevelManager.isIsRunStars)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(true);
            }
        }
        else
        {
            Cubes.cubesQuant = 0;
            Cubes.maxCubes = 0;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Crosshair.SetActive(false);
        }
    }

    void Win()
    {
        victoryPanel.SetActive(true);
        isStart = false;
        Laser.SetActive(false);

        if (isStar1)
        {
            quantStars += 1;
        }

        if (isStar2)
        {
            quantStars += 2;
        }

        if (isStar3)
        {
            quantStars += 3;
        }

        panelScoreWin.text = ScanBar.score.ToString();
    }

    void Lost()
    {
        isStart = false;

        loserPanel.SetActive(true);
        Laser.SetActive(false);
        panelScoreLoser.text = ScanBar.score.ToString();
    }

    void BuySecondWorld()
    {
        quantStars -= 10;

        //Unlock the world
        secondWorld = true;
    }

    void BuyThirdWorld()
    {
        quantStars -= 15;

        //Unlock the world
        thirdWorld = true;
    }
}
