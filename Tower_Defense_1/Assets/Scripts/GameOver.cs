using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI roundsShadow;
    public SceneFader sceneFader;
    public string sceneName = "MsinMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
        roundsShadow.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
sceneFader.FadeTo(SceneManager.GetActiveScene().name);    }

    public void Menu()
    {
        sceneFader.FadeTo(sceneName);
    }
}
