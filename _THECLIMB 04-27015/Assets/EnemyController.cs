using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Vector3 distance;
	public bool canFly;
	public float moveSpeed = 5.0f;
	public Transform player;
	public float maxSpeed;
	public float detectionRadius = 1;
	public CircleCollider2D dRad;
	void Start () {
		player = GameObject.Find ("Player").transform;
		dRad = gameObject.GetComponent<CircleCollider2D> ();
		dRad.radius = detectionRadius;

	}
	
	// Update is called once per frame
	void Update () {
		if (dRad.IsTouching (player.GetComponent<CircleCollider2D>())) {
				Debug.Log ("Player Detected");
					
			distance = player.transform.position - transform.position;

			if (distance.x < .5)
			{
				transform.localScale = new Vector2(-1,1);
				GetComponent<Rigidbody2D>().AddForce (-Vector2.right * moveSpeed);
			}
			else if ( distance.x > -.5)
			{
				transform.localScale = new Vector2(1,1);
				GetComponent<Rigidbody2D>().AddForce (Vector2.right * moveSpeed);
			}

			if 	(canFly)
			{
				if (distance.y < .5)
				{

					GetComponent<Rigidbody2D>().AddForce (-Vector2.up * moveSpeed);
				}
				else if ( distance.y > -.5)
				{

					GetComponent<Rigidbody2D>().AddForce (Vector2.up * moveSpeed);
				}
			}
		}
	}
}
