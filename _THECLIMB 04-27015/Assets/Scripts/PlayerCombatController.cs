using UnityEngine;
using System.Collections;

public class PlayerCombatController : MonoBehaviour {

	public GameObject[] weapons;
	private Transform muzzle;
	public float itemLife = 2.0f;
	private ItemWeapon weapon;
	private GameObject selectedWeapon;


	void Start () {
		if (selectedWeapon == null)
		selectedWeapon = weapons [0];
		muzzle = GameObject.Find ("PlayerMuzzle").transform;
		weapon = selectedWeapon.GetComponent<ItemWeapon> ();
		EquipSelectedWeapon ();

	}

	void Update () {
		ScanForWeaponChanges ();
		if (Input.GetButtonDown ("Fire1"))
		{
			if ((weapon.itemType == ItemWeapon.ItemType.Projectile || weapon.itemType == ItemWeapon.ItemType.Thrown))
				ShootWeapon();
			else
			{
				SwingWeapon();
			}
		}
	}

	private void ScanForWeaponChanges()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			selectedWeapon = weapons [0];
			EquipSelectedWeapon();
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			selectedWeapon = weapons [1];
			EquipSelectedWeapon();
		}
	}

	private void ShootWeapon ()
	{
		GameObject dupe = (GameObject)Instantiate(selectedWeapon, muzzle.position, muzzle.rotation);
		dupe.GetComponent<Rigidbody2D>().velocity = new Vector2((GetComponent<Rigidbody2D>().velocity.x) + (transform.localScale.x * weapon.speed), 0);
		dupe.transform.localScale = transform.localScale;
		Destroy(dupe, itemLife);
	}

	private void SwingWeapon()
	{
		Debug.Log ("Melee Brah!");
	}

	private void EquipSelectedWeapon()
	{
		muzzle.gameObject.GetComponent<SpriteRenderer> ().sprite = selectedWeapon.GetComponent<ItemWeapon> ().itemIcon;
	}
}
