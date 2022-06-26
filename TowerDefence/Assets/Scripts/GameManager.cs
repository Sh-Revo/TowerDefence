using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    //public string nextLevel;
    //public int levelToUnclock = 2;

    //public SceneFader sceneFader;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        //PlayerPrefs.SetInt("levelReach", 2);
        //sceneFader.FadeTo(nextLevel);
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
