using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject gunLocation;
    public GameObject projectile;
    private GameObject player;
    public float shootDelay = 5.0f;

    private float currentTime = 0.0f;

    private GameObject projectileParent; // tidy up all projectiles in a empty parent


	// Use this for initialization
	void Start () {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

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
                GameObject clone = (GameObject)Instantiate(projectile, gunLocation.transform.position, gunLocation.transform.rotation);
                clone.transform.parent = projectileParent.transform;
            }
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}
