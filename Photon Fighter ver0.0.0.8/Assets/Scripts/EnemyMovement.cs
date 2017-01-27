using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private Waypoints wpoints;
    private GameObject player;
    private GameObject enemy;
    private Rigidbody rb;
    public int index = 0;

    public GameObject waypoints;
    public float speed;

    public bool random = false;
    public bool moving = true;


	// Use this for initialization
	void Start () {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        rb = GetComponent<Rigidbody>();
        wpoints = waypoints.GetComponent<Waypoints>();
        index = GetRandomIndex();
        
    }
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(gameObject.transform.position, wpoints.points[index].transform.position);
        if (distance <= 1)
        {
            if (!random)
            {
                if (index + 1 == wpoints.points.Length)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            else
            {
                index = GetRandomIndex();
            }
        }

        if (moving)
        {
            Move();
        }
        
	}
    public void Move()
    {
        //gameObject.transform.LookAt(wpoints.points[index].transform.position);
        if (player != null)
        {
            gameObject.transform.LookAt(player.transform.position);
            gameObject.transform.position = Vector3.MoveTowards(transform.position, wpoints.points[index].position, speed * Time.deltaTime);
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    
    int GetRandomIndex()
    {
        return Random.Range(0, wpoints.points.Length);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            int newIndex = GetRandomIndex();

            while(newIndex == index)
            {
                newIndex = GetRandomIndex();
            }
            index = newIndex;
        }
    }

}