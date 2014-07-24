using UnityEngine;
using System.Collections;

public class RollGround : MonoBehaviour {

	// temp solution for testing
	[SerializeField] float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Roll(float move, bool crouch, bool jump)
	{
		// Reduce the speed if crouching by the crouchSpeed multiplier
		move = (crouch ? move * crouchSpeed : move);

		// Move the ground
		rigidbody2D.velocity = new Vector2(move * maxSpeed, 0.0f);
	}
}
