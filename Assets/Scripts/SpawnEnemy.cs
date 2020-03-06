using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpawnEnemy : NetworkBehaviour {

    float timer = 0;
    public GameObject enemyObject;
    private GameObject enemySyncSpawn;
    public float delaySpawn;
    
    private bool isEnemySpawn = false;

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer || isEnemySpawn)
            return;

        if(NetworkServer.connections.Count == 2)
        {
            timer += Time.deltaTime;

            if(timer >=delaySpawn)
            {
                GameObject spawnEnemy = (GameObject)Instantiate(enemyObject, new Vector3(Random.Range(-7.87f, 7.87f), 4.18f), Quaternion.identity);
                NetworkServer.Spawn(spawnEnemy);
                timer = 0;
            }
        }

    }
}
