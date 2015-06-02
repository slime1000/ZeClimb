using UnityEngine;
using System.Collections;

public class MenuButtonz : MonoBehaviour {

	public void QuitButton()
	{
		Application.Quit();
	}

	public void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void StartGame()
	{
		Application.LoadLevel(1);
	}

}
