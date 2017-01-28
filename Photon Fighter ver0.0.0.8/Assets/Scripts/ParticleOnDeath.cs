using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnDeath : Death {

	public ParticleSystem partSystsem;

    private GameObject particleParent;

	// Use this for initialization
	void Start () {
        particleParent = GameObject.Find("ParticleSystems");
        if(!particleParent)
        {
            particleParent = new GameObject("ParticleSystems");
        }


        if (!partSystsem) {
			Debug.LogError(name + " has no particle emitter attached!");
		}
	}
	
	public override void OnDeath() {
		// play particle effect, then destroy
		ParticleSystem emitter = (ParticleSystem)Instantiate(partSystsem, transform.position, Quaternion.identity);
        emitter.transform.parent = particleParent.transform;

        emitter.Play();

		Destroy(gameObject);
	}
}
