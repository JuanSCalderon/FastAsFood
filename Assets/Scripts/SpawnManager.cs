using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public GameObject[] spawnPoints;

    private float startDelay = 1;
    private float spawnInterval = 1f;
    public bool canSpawn = true;
    
    void Start() {
        InvokeRepeating("SpawnRandomFood", startDelay, spawnInterval);
    }

    void SpawnRandomFood()
    {
        if (!canSpawn || spawnPoints.Length == 0) return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject selectedSpawnPoint = spawnPoints[spawnIndex];

        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Instantiate(foodPrefabs[foodIndex], selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.rotation);
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
}
