using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject star;
 
    [SerializeField] private float maxX;
    [SerializeField] private Transform spawnPoint;
   
    [SerializeField] private float spawnRateStar;
    bool gameStarted = false;

    private void Update()
    {
        if (!gameStarted)
        {
            startSpawning();
            gameStarted = true;
        }
    }

    private void startSpawning()
    {
        InvokeRepeating("spawnPowerup", 1f, spawnRateStar);
      
    }
    private void spawnPowerup()
    {
        Vector3 powerupSpawnPos = spawnPoint.position;
        powerupSpawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(star, powerupSpawnPos, Quaternion.identity);
    }
}
