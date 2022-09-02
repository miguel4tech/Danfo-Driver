using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Variables 
    //Variable
    public GameObject[] animalsPrefabs;
    float spawnRangeX = 20;
    float spawnPosZ = 20;
    float startDelay =2;
    float spawnInterval = 1.5f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomAnimal()
    {
            //Randomly make animals appear in random spawn position
            int animalIndex = Random.Range(0, animalsPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0, spawnPosZ);

            //Appear call
            Instantiate(animalsPrefabs[animalIndex], spawnPos, animalsPrefabs[animalIndex].transform.rotation);
    }
}
