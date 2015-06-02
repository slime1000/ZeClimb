using UnityEngine;
using System.Collections;

public class ItemWeapon : Item {

	public enum ItemType
	{
		Melee,
		Thrown,
		Projectile
	}

	public ItemType itemType;

	public float speed;
	public float damage;
}
