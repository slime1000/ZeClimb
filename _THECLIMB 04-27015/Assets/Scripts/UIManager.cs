using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Transform player;
	public Transform characterWindow;
	public Text name, level, xp, health, stamina, energy;
	PlayerManager pMan;
	void Start()
	{
		pMan = gameObject.GetComponent<PlayerManager> ();
		if (!player) player = GameObject.Find("Player").transform;
	}

	void Update()
	{
		name.text = pMan.cs.name;
		level.text = pMan.cs.level.ToString();
		xp.text = pMan.cs.xp.ToString();
		health.text = pMan.cs.health.ToString();
		stamina.text = pMan.cs.stamina.ToString();
		energy.text = pMan.cs.energy.ToString();

	}
}
