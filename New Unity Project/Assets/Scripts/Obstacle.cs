using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public static float scrollSpeed;

	private void Awake() {
			
	}

	void Update() {
		Move();
	}

	private void Move() {
		transform.position += Vector3.left * scrollSpeed;
	}
}
