using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private float hAxis, yAxis, velY;

	public float jumpPower;
	public float climbSpeed = 5.0f;
	public float wallJumpX = 10.0f;
	public float wallJumpY = 10.0f;
	public float moveSpeed = 5.0f;
	public float airVelocity = 1.5f;
	
	public Transform hands, feet, groundCheck, grasp;

	void Start () {
		animator = gameObject.GetComponent <Animator> ();
	}

	void FixedUpdate () {
		GetPlayerInput ();
		GetPlayerVelocity ();
		ApplyLocomotion ();
		
	}

	private void GetPlayerVelocity ()
	{
		velY = GetComponent<Rigidbody2D>().velocity.y;
	}

	private void GetPlayerInput()
	{
		hAxis = Input.GetAxis ("Horizontal") * moveSpeed;
		yAxis = Input.GetAxis ("Vertical") * climbSpeed;

		if (hAxis < 0) transform.localScale = new Vector2 (-1,1);
		else if (hAxis > 0) transform.localScale = new Vector2 (1,1);
	}

	private void ApplyLocomotion()
	{
		if (IsOnWall())
		{
			ApplyWallLocomotion();
		}
		else if (IsGrounded()) 
		{
			ApplyGroundLocomotion();
		}
		else ApplyAirLocomotion();

		if (hAxis == 0 && IsGrounded()) GetComponent<Rigidbody2D>().velocity = new Vector2(0,velY);
		CheckJump ();
	}

	private void ApplyWallLocomotion()
	{
		GetComponent<Rigidbody2D>().isKinematic = true;
		GetComponent<Rigidbody2D>().velocity =  new Vector2(0,yAxis);
		animator.SetFloat ("ClimbSpeed",Mathf.Abs (yAxis));
	}
	private void ApplyGroundLocomotion()
	{
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().velocity =  new Vector2(hAxis,velY);
		animator.SetFloat ("Speed",Mathf.Abs (hAxis));
	}
	private void ApplyAirLocomotion()
	{
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().AddForce(new Vector2 (hAxis * airVelocity,velY));
		animator.SetFloat ("Speed",0);
	}

	private void CheckJump()
	{
		if (Input.GetButton ("Jump") && IsGrounded())
		{
			animator.SetTrigger("Jump");
			GetComponent<Rigidbody2D>().velocity = new Vector2 (hAxis, jumpPower);
			Debug.Log ("Jumping");
		}
		else if (Input.GetButton ("Jump") && IsOnWall()) 
		{
			animator.SetTrigger("Jump");
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-transform.localScale.x * wallJumpX, wallJumpY);
			Debug.Log ("Jumping");

		}
	}
	public bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.Raycast(feet.transform.position, -Vector2.up, 
			Vector3.Distance(feet.transform.position, 
		    groundCheck.transform.position));
		Debug.DrawLine (feet.transform.position, groundCheck.transform.position, Color.red);
		if (hit.collider != null && (hit.collider.tag == "Environment" || hit.collider.tag == "Enemy")) {
			Debug.Log(hit.collider.name);
			return true;
		}
		return false;
	}

	public bool IsOnWall()
	{

		RaycastHit2D hit = Physics2D.Raycast(hands.transform.position, -Vector2.up, 
		Vector3.Distance(hands.transform.position, 
		grasp.transform.position));
		Debug.DrawLine (hands.transform.position, grasp.transform.position , Color.red);
		if (hit.collider != null && hit.collider.tag == "Environment") {
			animator.SetBool("WallHang", true);
			Debug.Log(hit.collider.name);
			return true;
		}
		animator.SetBool("WallHang", false);
		return false;
	}

}
