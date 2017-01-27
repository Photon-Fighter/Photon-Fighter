using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour {

	public int damage;

	bool dealtDamage = false;

	void Start() {
		
	}

	void Update() {
		transform.position += Vector3.right * 5f * Time.deltaTime;
	}

	void OnTriggerEnter(Collider coll) {
		Health health = coll.GetComponent<Health>();

		if(health != null && !dealtDamage) {
			dealtDamage = true;
			health.Damage(damage);
		}

		Destroy(gameObject);
	}
}
