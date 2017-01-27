using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWave : MonoBehaviour {

	public int damage;

	bool dealtDamage = false;

	public Weapons.Weapon weapon;
	public PhotonColor color;

	// Use this for initialization
	void Start () {
		
		weapon = transform.parent.GetComponent<ProjectileMovement>().weapon;
		color = transform.parent.GetComponent<ProjectileMovement>().color;
	}
	
	// Update is called once per frame
	void Update () {
        // for vertical oscillation as well
        //transform.localPosition = new Vector2( Mathf.Sin(Time.time*speed)*amplitude, Mathf.Sin(Time.time * speed) * amplitude);

        transform.localPosition = new Vector2( Mathf.Sin(Time.time*speed)*amplitude, 0f);
		//transform.localPosition = new Vector2( Mathf.Sin(Time.time*weapon.amplitudeSpeed)*weapon.amplitudeHorizontal, 0f);

    }

    void OnTriggerEnter(Collider coll) {
		Health health = coll.GetComponent<Health>();

		if(health != null && !dealtDamage) {
			dealtDamage = true;
			//health.Damage(damage);

			health.Damage(weapon.projectileDamage);
		}

		Destroy(gameObject);
	}
    
    public float speed = 5.0f;
    public float amplitude = 5.0f;
    

}
