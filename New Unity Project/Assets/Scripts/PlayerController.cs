using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public KeyCode jumpButton;
	public float jumpStrength;
	public float floorYPosition;
	public float gravity;
	private Vector3 velocity;

	private void Awake() {
		velocity = new Vector3();	
	}

	void Update() {
		Move();
	}

	private void Move() {
		if (Input.GetKeyDown(jumpButton) && 
			transform.position.y == floorYPosition) {
			Debug.Log("pressed jumpButton");
			Jump();
		}
		ApplyGravity();

		//apply velocity
		transform.position = transform.position + velocity;

		//make sure it never goes below floorYPosition
		HitFloor();
	}

	private void HitFloor() {
		if (transform.position.y <= floorYPosition) {
			transform.position = new Vector3(
				transform.position.x, floorYPosition, transform.position.z);
		}
	}

	private void ApplyGravity() {
		velocity += new Vector3(velocity.x, -gravity, velocity.z);
	}

	private void Jump() {
		velocity = new Vector3(velocity.x, jumpStrength, velocity.z);
	}
}
