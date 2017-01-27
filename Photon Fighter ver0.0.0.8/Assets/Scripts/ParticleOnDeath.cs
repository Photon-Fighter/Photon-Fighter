using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnDeath : Death {

	public ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
		if(!particleSystem) {
			Debug.LogError(name + " has no particle emitter attached!");
		}
	}
	
	public override void OnDeath() {
		// play particle effect, then destroy
		ParticleSystem emitter = (ParticleSystem)Instantiate(particleSystem, transform.position, Quaternion.identity);
		emitter.Play();

		Destroy(gameObject);
	}
}
