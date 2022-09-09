using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBall : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefabs;

    Vector3 spawnPos = new Vector3(0, 0, 6);
    float spawnRange = 9;
    int enemyCount;
    int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefabs, GenerateRandomPos(), powerupPrefabs.transform.rotation);
    }

    void SpawnEnemyWave( int enemiesToSpan)
    {
        for (int i = 0; i < enemiesToSpan; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                Instantiate(powerupPrefabs, GenerateRandomPos(), powerupPrefabs.transform.rotation);
            }
    }

    Vector3 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(-spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
