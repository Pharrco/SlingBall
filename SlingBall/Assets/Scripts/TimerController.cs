using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	[SerializeField]
	Text timer_text;

	[SerializeField]
	GameObject reset_panel;

	float time_remaining = 0f;

	// Update is called once per frame
	void Update () {
		// If there is time remaining
		if (time_remaining > 0)
		{
			// Reduce the time remaining by the time elapsed since last update
			time_remaining -= Time.deltaTime;

			// Update the text string
			timer_text.text = Mathf.CeilToInt(time_remaining).ToString();
		}
		else
		{
			// Game over
			// Pause the game
			MasterController.Pause();

			// Show the game over screen
			reset_panel.SetActive(true);
		}
	}

	public void ResetTimer()
	{
		// Set initial time
		time_remaining = 30f;

		// Unpause the game
		MasterController.Unpause();

		// Hide the game over panel
		reset_panel.SetActive(false);
	}
}
