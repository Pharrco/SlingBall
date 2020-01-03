using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClickHandler : MonoBehaviour {

	[SerializeField]
	GameObject held_ball;
	Collider2D ball_collider;

	// Use this for initialization
	void Start () {
		ball_collider = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// When the mouse button is clicked and the game is not paused
		if ((Input.GetMouseButtonDown(0)) && (!MasterController.isPaused))
		{
			// Get mouse position
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			// Raycast to determine if any object is hit
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

			// If an object is hit and if that object is the collider attached to this game object
			if ((hit.collider != null) && (hit.collider == ball_collider))
			{
				// Instantiate a held ball
				GameObject.Instantiate(held_ball, new Vector3(mousePos2D.x, mousePos2D.y, 0), Quaternion.identity);

				// Destroy the stationary ball
				GameObject.Destroy(gameObject);
			}
		}
	}
}
