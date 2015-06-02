using UnityEngine;
using System.Collections;

public class GlobalConditions : MonoBehaviour {
	public int killZ = -10;
	private Transform player;

	void Start () {
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
			Debug.Log ("Player Found - KillZ scan initialized...");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && player.transform.position.y < killZ) 
		{
			Application.LoadLevel(Application.loadedLevel);	
		}
	}
}
