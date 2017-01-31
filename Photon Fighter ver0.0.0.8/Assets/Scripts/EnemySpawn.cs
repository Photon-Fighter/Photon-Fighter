using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    private GameObject player;
    public float spawnTime;
    public float delay = 0;
    public Transform[] spawnPoints;

    private GameObject enemyParent; // tidy up all enemies in a empty parent

	// Use this for initialization
	void Start () {
        enemyParent = GameObject.Find("Enemies");
        if (!enemyParent)
        {
            enemyParent = new GameObject("Enemies");
        }

        InvokeRepeating("Spawn", delay, spawnTime); //Second param is start delay
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
	
	// Update is called once per frame
	void Spawn () {
        int spawnPointInd = Random.Range(0, spawnPoints.Length);
        //if (Time.time < GameTimer.maxTime) //Change on GameTimer class
        //{
        if (player != null)
        {
            GameObject clone = (GameObject)Instantiate(enemy, spawnPoints[spawnPointInd].position, spawnPoints[spawnPointInd].rotation);
            clone.transform.parent = enemyParent.transform;
        }
        //}
	}

}
