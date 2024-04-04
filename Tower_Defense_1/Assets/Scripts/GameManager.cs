using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver == true)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
