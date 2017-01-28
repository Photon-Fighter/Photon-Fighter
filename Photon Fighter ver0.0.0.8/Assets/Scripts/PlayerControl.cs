using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public GameObject projectile;
    private GameObject projectileParent; // tidy up all projectiles in a empty parent

    public GameObject gunLocation;

	public float moveSpeed = 20.0f;
	public float rotationSpeed = 5.0f;
	Rigidbody rb;

	public float maxVelocity = 10.0f;

	public Weapons.Weapon myWeapon;
	private int curWeapon = 0;
	private int maxWeapons;

    // Use this for initialization
    void Start() {
        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

		rb = GetComponent<Rigidbody>();

		if(!rb) {
			Debug.LogError(name + " doesn't have a rigidbody component");
		}

		maxWeapons = System.Enum.GetNames(typeof(PhotonColor)).Length;
		Debug.Log("number of weapons: " + System.Enum.GetNames(typeof(PhotonColor)).Length);

        EquipWeapon();
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
            proj.transform.parent = projectileParent.transform;
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
        // make sure our weapons have been instantiated
        if (Weapons.weapons != null)
        {
            myWeapon = Weapons.weapons[(PhotonColor)curWeapon];
            projectile = myWeapon.projectile;

            Debug.Log("Changed weapon to: " + projectile.name + " " + myWeapon.color);
        }
	}

	// logic to check for player rotation and movement
	void MovePlayer() {

        // The directions seem off here because of the orientation of the camera.
        // It is looking at the world from the +x direction
        // because of this, the directions are as follows, from the player's perspective:
        //      a = Vector3.back (-z)
        //      d = Vector3.forward (+z)
        //      w = Vector3.left (-x)
        //      s = Vector3.right (+x)
        if (Input.GetKey(KeyCode.A)) {
            //transform.RotateAround(transform.position, Vector3.up, -rotationSpeed);
            MoveTowards(Vector3.back);
        }
		else if(Input.GetKey(KeyCode.D)) {
            //transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
            MoveTowards(Vector3.forward);
        }

		if(Input.GetKey(KeyCode.W)) {
            //MoveTowards(transform.forward);
            MoveTowards(Vector3.left);
        }
		else if(Input.GetKey(KeyCode.S)) {
            //MoveTowards(-transform.forward);
            MoveTowards(Vector3.right);
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
