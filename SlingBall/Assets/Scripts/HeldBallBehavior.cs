using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldBallBehavior : MonoBehaviour {

	[SerializeField]
	GameObject ball_prefab;

	[SerializeField]
	float max_distance = 3f;

	Vector3 aim_point = new Vector3(0, -1.8f, 0);
	LineRenderer line;

	// Use this for initialization
	void Start () {
		// Get line renderer for slingshot band
		line = GetComponent<LineRenderer>();

		// Set initial position of middle of slingshot band
		line.SetPosition(1, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		// If the mouse button is held down and the game is not paused
		if ((Input.GetMouseButton(0)) && (!MasterController.isPaused))
		{
			// Get the mouse position
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 new_position= new Vector3(mousePos.x, mousePos.y, 0);

			// If the mouse's position is within the maximum distance from the aim point
			if (Vector3.Distance(new_position, aim_point) < max_distance)
			{
				// Place the ball at the mouse's position
				transform.position = new_position;

				// Set the new position of the middle of the slingshot band
				line.SetPosition(1, new_position);
			}
		}
		// If the mouse button has been released and the game is not paused
		else if ((Input.GetMouseButtonUp(0)) && (!MasterController.isPaused))
		{
			// Instantiate a new moving ball
			GameObject new_ball = GameObject.Instantiate(ball_prefab, transform.position, Quaternion.identity);

			// Send the balls position and the aim point to the new ball
			new_ball.GetComponent<BallMovement>().SetVelocity(transform.position, aim_point);

			// Destroy this object
			GameObject.Destroy(gameObject);
		}
	}
}
