using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public GameObject projectile; // TODO: create separate script for this?

	public GameObject gunLocation;

	public float moveSpeed = 20.0f;
	public float rotationSpeed = 5.0f;
	Rigidbody rb;

	public float maxVelocity = 10.0f;

	public Weapons.Weapon myWeapon;
	private int curWeapon = 0;
	private int maxWeapons;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		if(!rb) {
			Debug.LogError(name + " doesn't have a rigidbody component");
		}

		EquipWeapon();

		maxWeapons = System.Enum.GetNames(typeof(PhotonColor)).Length;
		Debug.Log("number of weapons: " + System.Enum.GetNames(typeof(PhotonColor)).Length);
	}
	
	// Update is called once per frame
	void Update () {
		Shoot();
		SwitchWeapon();
	}

	void FixedUpdate() {
        rb.angularVelocity = Vector3.zero;
		MovePlayer();
	}

	void Shoot() {
		if(Input.GetMouseButtonDown(0)) {
			GameObject proj = (GameObject)Instantiate(projectile, gunLocation.transform.position, gunLocation.transform.rotation);
		}
	}

	void SwitchWeapon() {
		if(Input.GetKeyDown(KeyCode.Q)) {
			curWeapon--;

			if(curWeapon < 0) {
				curWeapon = maxWeapons - 1;
			}

			EquipWeapon();
		}
		else if(Input.GetKeyDown(KeyCode.E)) {
			curWeapon++;
			if(curWeapon >= maxWeapons) {
				curWeapon = 0;
			}

			EquipWeapon();
		}
	}

	void EquipWeapon() {
		//myWeapon = Weapons.weapons[(PhotonColor)(curWeapon / System.Enum.GetNames(typeof(PhotonColor)).Length)];
		myWeapon = Weapons.weapons[(PhotonColor)curWeapon];
		projectile = myWeapon.projectile;

		Debug.Log("Changed weapon to: " + projectile.name + " " + myWeapon.color);
	}

	// logic to check for player rotation and movement
	void MovePlayer() {
		if(Input.GetKey(KeyCode.A)) {
			transform.RotateAround(transform.position, Vector3.up, -rotationSpeed);
		}
		else if(Input.GetKey(KeyCode.D)) {
			transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
		}

		if(Input.GetKey(KeyCode.W)) {
			MoveTowards(transform.forward);
		}
		else if(Input.GetKey(KeyCode.S)) {
			MoveTowards(-transform.forward);
		}
	}

	// denote the direction to move the player
	// uses the player speed and the v`ector direction provided
	void MoveTowards(Vector3 moveDirection) {
		if(rb.velocity.magnitude <= maxVelocity) {
			rb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
		}
		else {
			// this is broken!!!!
			rb.AddForce(moveDirection * moveSpeed * 0.000001f * Time.deltaTime);
		}
	}
}
