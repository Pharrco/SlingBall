using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {

	public static bool isPaused = false;

	// Pause the game
	public static void Pause()
	{
		isPaused = true;
	}

	// Unpause the game
	public static void Unpause()
	{
		isPaused = false;
	}

	private void Update()
	{
		// If the escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// Quit the game
			Application.Quit();
		}
	}
}
