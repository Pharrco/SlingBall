using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour {

	// When the ball collides with a wall
	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Add one to the score
		ScoreController.AddToScore(1);
	}
}
