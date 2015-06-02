using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	void Start () {
	if (player == null)
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GetPlayerPosition();
	}

	private Vector3 GetPlayerPosition()
	{
		return new Vector3 (player.position.x, player.position.y,-10);
	}
}
