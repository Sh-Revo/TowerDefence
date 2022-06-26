using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;
    public GameManager gameManager;
    private float _countdown = 2f;
    private int _waveIndex = 0;

    private void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }
        if (_waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            return;
        }
        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("Time: {0:00.00}", _countdown);
    }

    IEnumerator SpawnWave()
    {
        
        PlayerStats.rounds++;
        Wave wave = waves[_waveIndex];
        //enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        _waveIndex++;
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
