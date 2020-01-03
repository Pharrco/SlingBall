using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	[SerializeField]
	Text score_text;

	static int score_global = 0;
	int score_local;

	// Use this for initialization
	void Start () {
		// Set initial local score
		score_local = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// If the score has been updated
		if (score_local != score_global)
		{
			// Update the local score
			score_local = score_global;

			// Update the score text
			score_text.text = score_local.ToString();
		}
	}

	// Add given amount to global score
	public static void AddToScore(int amount)
	{
		// If the game is not paused
		if (!MasterController.isPaused)
		{
			// Add the amount to the score
			score_global += amount;
		}
	}

	// Reset global score to zero
	public void ResetScore()
	{
		// Reset the score
		score_global = 0;
	}
}
