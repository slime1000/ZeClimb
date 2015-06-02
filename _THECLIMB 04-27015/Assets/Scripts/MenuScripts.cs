using UnityEngine;
using System.Collections;

public class MenuScripts : MonoBehaviour {

	public GameObject inventoryPanel;

	void start ()
	{
		if (inventoryPanel == null) 
		{
			GameObject.Find ("Inventory");
		}
	}

	public void StartGame()
	{
		Application.LoadLevel ("Debug");
	}

	public void  QuitGame()
	{
		Application.Quit ();
	}

	public void RestartLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ToggleInventory()
	{
		inventoryPanel.SetActive(!inventoryPanel.activeSelf);
	}


}
