using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {

	// Weapon manager class to put on player/enemies for cycling through weapons?

	// base class for all weapons
	// projectile will either be a projectile prefab or the player in the case of a dash

	//public GameObject projectile;


	// the Attack method will be overridden to implement attack functionality
	// dash - affect the player's position
	// or can spawn projectiles with whatever desired behavior
	public abstract void Attack();
}

