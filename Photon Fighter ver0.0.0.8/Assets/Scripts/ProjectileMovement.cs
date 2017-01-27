using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

	//GameObject player;
	Vector3 moveDir;

	public Weapons.Weapon weapon;

    //public GameObject destination;
    //Vector2 startPosition;
    float distance;
    public float speed = 1.0f;
    public float projectileTime = 0.0f;
    
	public PhotonColor color;

    // Use this for initialization
    void Start () {
        //startPosition = transform.position;
		//moveDir = transform.forward * speed;

		weapon = Weapons.weapons[color];

		moveDir = transform.forward * weapon.projectileSpeed;
		//moveDir = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
        
        //transform.position = Vector3.MoveTowards(transform.position, moveDir + transform.position, speed * Time.deltaTime);

		transform.position = Vector3.MoveTowards(transform.position, moveDir + transform.position, weapon.projectileSpeed * Time.deltaTime);

		
    }



}
