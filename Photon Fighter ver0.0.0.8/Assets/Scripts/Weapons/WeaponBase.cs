using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour {

	public GameObject basicProjectile;

	public float projectileSpeed;
	public float amplitudeHorizontal;

	public float amplitudeSpeed;
	public int projectileDamage;

	public PhotonColor color;

	// Use this for initialization
	void Start () {
		if(Weapons.weapons == null) {
			Weapons.weapons = new Dictionary<PhotonColor, Weapons.Weapon>();
		}

		Weapons.Weapon newWeapon = new Weapons.Weapon();
		Weapons.weapons.Add(color, newWeapon);

		newWeapon.amplitudeHorizontal = amplitudeHorizontal;
		newWeapon.amplitudeSpeed = amplitudeSpeed;
		newWeapon.color = color;
		newWeapon.projectile = basicProjectile;
		newWeapon.projectileDamage = projectileDamage;
		newWeapon.projectileSpeed = projectileSpeed;

	}
}
