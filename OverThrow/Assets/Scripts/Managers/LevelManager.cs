using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject World2Locked;
    public GameObject noStars;
    public static bool purpleUnlocked = false;

    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public GameObject endGame;
    public GameObject tutorialBoss;

    public bool star1;
    public bool star2;
    public bool star3;
    //Levels controller
    public bool isLvl10;
    public bool isLvl11;

    public bool isRunStars;
    public static bool isIsRunStars;
    public static bool isIsLvl15;

    public bool isTheBoss;
    public static bool isIsTheBoss;

    public static int hp = 3;

    public bool isLvl20;

    private void Start()
    {
        hp = 3;
    }
    private void FixedUpdate()
    {
        if (isLvl10 && GameManager.isWin)
        {
            SceneManager.LoadScene("WorldScene");
        }

        if (purpleUnlocked)
        {
            World2Locked.SetActive(false);
        }

        if (isLvl20 && GameManager.isWin)
        {
            endGame.SetActive(true);
            GameManager.isStart = false;
        }

        if (isRunStars)
        {
            isIsRunStars = true;
        }

        if (isTheBoss)
        {
            isIsTheBoss = true;
            StartCoroutine(TutorialBossDisable());
        }
    }

    IEnumerator TutorialBossDisable()
    {
        yield return new WaitForSeconds(2.5f);
        tutorialBoss.SetActive(false);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //AudioManager.instance.Play("ThemeMusic");
        GameManager.isStart = true;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Lvl1");
        GameManager.isStart = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("WorldScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Video()
    {
        SceneManager.LoadScene("Video");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    //Worlds
    public void World1()
    {
        SceneManager.LoadScene("Lvl1");
        GameManager.isStart = true;
    }
    public void World2()
    {
        if (purpleUnlocked)
        {
            SceneManager.LoadScene("Lvl11");
            GameManager.isStart = true;
        }

        if (GameManager.quantStars >= 25)
        {
            GameManager.quantStars -= 25;
            World2Locked.SetActive(false);
            purpleUnlocked = true;
        }
        else
        {
            noStars.SetActive(true);
            StartCoroutine(DisableBgRed());
        }
    }

    IEnumerator DisableBgRed()
    {
        yield return new WaitForSeconds(0.25f);
        noStars.SetActive(false);
    }
    public void World3()
    {
        if (GameManager.quantStars >= 35)
        {
            SceneManager.LoadScene("Lvl21");
        }

        else
        {
            noStars.SetActive(true);
        }
    }

    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.isStart = true;
        //ScanBar.score = GameManager.lastMinScore;
    }

    public void CloseNoStars()
    {
        noStars.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
