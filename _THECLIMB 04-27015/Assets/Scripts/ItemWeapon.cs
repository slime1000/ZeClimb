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


	public void OnTriggerEnter2D (Collider2D obj)
	{
		if(obj.tag == "Enemy")
			Destroy (obj.gameObject);
	}
}
