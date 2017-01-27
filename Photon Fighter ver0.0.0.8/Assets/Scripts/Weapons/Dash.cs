using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability {

	// projectile will be the player in this case
	public float moveSpeed = 500f;
	Rigidbody rb;

	float dashStart;
	public float dashTime = 0.5f;

	void Start() {
		rb = GetComponent<Rigidbody>();

		if(!rb) {
			Debug.LogError(name + " can't dash - needs a rigidbody");
		}
	}

	void Update() {
		/*if(dashStart > 0 && Time.time - dashStart > dashTime) {
			ResetVelocity();
			dashStart = -1f;
		}*/
	}

	public override void Attack() {
		// raycast to see if there is an enemy?
		/*
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		LayerMask layerMask = 1 << 11;
		if(Physics.Raycast(transform.position, fwd, 100f, layerMask)) {
			Debug.Log("See enemy");
		}
		else {
			Debug.DrawRay(transform.position, fwd, Color.red);
		}*/

		dashStart = Time.time;


		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		//rb.AddForce(transform.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);

		//ResetVelocity();
	}


	void ResetVelocity() {
		//yield return new WaitForSeconds(0.05f);
		rb.AddForce(-transform.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
	}
}
