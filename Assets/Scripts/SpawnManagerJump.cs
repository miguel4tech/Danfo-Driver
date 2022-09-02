using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerJump : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    Vector3 spawnPos = new Vector3(20,0,0);
    JumperContr playerControllerScript;
    float startDelay = 2.0f;
    float repeatRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<JumperContr>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
        }
    }
}
