using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public Transform player;
	public CharacterSheet cs = new CharacterSheet();

	void Start () {

		if (!player) player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (cs.health < 1)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
