using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public static float scrollSpeed;

	private void Awake() {
		Disable();	
	}

	void Disable() {
		gameObject.SetActive(false);
	}

	void Update() {
		Move();
		CheckIfOutOfBound();
	}

	private void Move() {
		Vector3 displacement = Vector3.left * scrollSpeed;
		transform.position += displacement;
	}

	private void CheckIfOutOfBound() {
		if (transform.position.x <= -10) {
			Disable();
		}
	}
}
