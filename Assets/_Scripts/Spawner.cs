using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject magnet;
    [SerializeField] private float maxX;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnRateMagnet;
    [SerializeField] private float spawnRateEnemy;
    [SerializeField] private float spawnRatePowerUp;
    bool gameStarted = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            startSpawning();
            gameStarted = true;
        }
    }

    private void startSpawning()
    {
        InvokeRepeating("spawnEnemy", 0.5f, spawnRateEnemy);
        InvokeRepeating("spawnPowerup", 1f, spawnRatePowerUp);
        InvokeRepeating("spawnMagnet", 1f, spawnRateMagnet);
    }

    private void spawnEnemy()
    {
        Vector3 EnemySpawnPos = spawnPoint.position;
        EnemySpawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(enemy, EnemySpawnPos, Quaternion.identity);
    }
    private void spawnPowerup()
    {
        Vector3 powerupSpawnPos = spawnPoint.position;
        powerupSpawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(powerUp, powerupSpawnPos, Quaternion.identity);
    }

    private void spawnMagnet()
    {
        Vector3 magnetSpawnPos = spawnPoint.position;
        magnetSpawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(magnet, magnetSpawnPos, Quaternion.identity);
    }


}
