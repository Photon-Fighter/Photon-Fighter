using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Weapons {

	public static Dictionary<PhotonColor, Weapon> weapons;

	public class Weapon {
		public GameObject projectile;
		public float projectileSpeed;
		public float amplitudeHorizontal;

		public float amplitudeSpeed;
		public int projectileDamage;

		public PhotonColor color;

		//public float amplitudeVertical;
	}
}

