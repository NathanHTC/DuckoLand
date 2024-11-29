using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//uses a singleton pattern to ensure only one instance of 
//game manager exists at any time
public class GameManager : MonoBehaviour
{
    // Singleton instance of GameManager
    //mark private only this class can modify this instance
    public static GameManager Instance { get; private set; }

    //enemyPrefab movement script is modified to generate random speed
    //and change direction at a random time
    public GameObject enemyPrefab;
    // public GameObject enemyPrefab2;
    // public GameObject enemyPrefab3;
    // Time between spawns
    public float spawnRate = 2f;    
    private bool isSpawning = false;

    // Ensure that there's only one instance of the GameManager
    //awake: when this script is being loaded
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void StartGeneratingEnemies()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnEnemiesCoroutine());
        }
    }

//the coroutine keeps track of the time 
    IEnumerator SpawnEnemiesCoroutine()
    {
        float endTime = Time.time + 6f;  
        // Run for 6 seconds

        while (Time.time < endTime)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);  
            // Wait for spawnRate(2 sec) duration before spawning next enemy
        }

        isSpawning = false;
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 20f));
        // Vector2 spawnPosition2 = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 20f));

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        // Instantiate(enemyPrefab2, spawnPosition2, Quaternion.identity);
        Debug.Log("Enemy spawned at: " + spawnPosition + " using Coroutine.");
    }
}




