using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject gunLocation;
    public GameObject projectile;
    private GameObject player;
    public float shootDelay = 5.0f;

    private float currentTime = 0.0f;
	// Use this for initialization
	void Start () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > shootDelay)
        {
            currentTime = 0.0f;
            if (player != null)
            {
                Instantiate(projectile, gunLocation.transform.position, gunLocation.transform.rotation);
            }
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}
