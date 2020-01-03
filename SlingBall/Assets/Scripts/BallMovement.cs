using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	[SerializeField]
	GameObject ball_prefab;

	Rigidbody2D body;

	float timer = 0f;

	private void Start()
	{
		// Get rigidbody
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		// If the timer is started
		if (timer > 0)
		{
			// Increment the timer
			timer -= Time.deltaTime;
		}

		// If the game is over
		if (MasterController.isPaused)
		{
			// Instantiate a new stationary ball
			GameObject.Instantiate(ball_prefab, new Vector3(0f, -1.8f, 0f), Quaternion.identity);

			// Destroy this ball
			GameObject.Destroy(gameObject);
		}
		// If the game is not paused and velocity has dropped below 0.1 vertical and 0.2 horizontal
		else if ((body.velocity.y == 0) && (body.velocity.x < 0.2f))
		{
			// Instantiate a new stationary ball
			GameObject.Instantiate(ball_prefab, new Vector3(0f, -1.8f, 0f), Quaternion.identity);

			// Destroy this ball
			GameObject.Destroy(gameObject);
		}
		// If the mouse button is clicked
		else if (Input.GetMouseButtonDown(0))
		{
			// If the timer is not already started
			if (timer <= 0)
			{
				// Set the timer
				timer = 1f;
			}
			// If the timer is already started (First click recognized)
			else
			{
				// Instantiate a new stationary ball
				GameObject.Instantiate(ball_prefab, new Vector3(0f, -1.8f, 0f), Quaternion.identity);

				// Destroy this ball
				GameObject.Destroy(gameObject);
			}
		}
	}

	// Add velocity to the ball using an elastic band by using the vector between the ball and the rubber band as a source
	public void SetVelocity(Vector3 init_pos, Vector3 aim_pos)
	{
		// Get the relative position and multiply it by 10 to achieve initial velocity
		Vector3 relative_vel = (aim_pos - init_pos) * 10;

		// Apply the calulated force to the rigidbody
		GetComponent<Rigidbody2D>().AddForce(new Vector2(relative_vel.x, relative_vel.y), ForceMode2D.Impulse);
	}
}
