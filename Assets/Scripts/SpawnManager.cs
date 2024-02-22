using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    public GameObject enemyPrefab;
    public float spawnTimer = 4f;

    void Awake()
    {
        Instance = this;
    }
    //Starts the enemy generation
    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTimer);
    }
    //
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnEnemy");
    }
}
