using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour
{
    public Wave[] waves;
    public static int EnemiesAlive = 0;
    
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI backdrop;
    private float countdown = 2f;
    public GameManager gameManager;
    private int waveIndex = 0;
    

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Math.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00:00}", countdown);
        backdrop.text = string.Format("{0:00:00}", countdown);
    }

    IEnumerator spawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        
    }

    private void spawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
