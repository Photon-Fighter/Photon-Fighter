using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health = 100;
    public ParticleSystem DeathEffect;
    public AudioClip DeathAudio;
    AudioSource enemyAudio;


    
    void Awake()
    {
        if (DeathEffect == null)
        {
            DeathEffect = GetComponent<ParticleSystem>();
        }
        if (DeathAudio == null)
        {
            DeathAudio = GetComponent<AudioClip>();
        }
        enemyAudio = GetComponent<AudioSource>();
    }

    // function to damage someone with the Health component


	// function to damage someone with the Health component
	public void Damage(int damage) {
		health -= damage;

		// if the health is less than 0, see if there is a death script
		if(health <= 0) {
            //Instantiate(DeathEffect, transform.position, transform.rotation);
            CheckDeath();
		}
	}

	void CheckDeath() {
        // using this to be a way to code if we need a special death
        //Death deathComponent = GetComponent<Death>();

        //if(deathComponent != null) {
        //	deathComponent.OnDeath();
        //}
        //else {
        // just destroy the game object


        //AudioSource.PlayClipAtPoint(DeathAudio,transform.position, 100f);
        enemyAudio.clip = DeathAudio;
        enemyAudio.Play();



        DeathEffect.Play();
        Instantiate(DeathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
		//}
	}
}
