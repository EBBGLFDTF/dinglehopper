using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFloor : MonoBehaviour
{

	public float scrollSpeed;

	private Transform[] childrenTransform;

	private float screenWidth;

	private void Awake() {
		childrenTransform = transform.GetComponentsInChildren<Transform>();
		screenWidth = CalculateScreenWidth();
	}

	private void Start() {
		PreplaceFloorObjects();					
	}

	void Update() {
		for (int i = 0; i < childrenTransform.Length; i++) {
			Move(childrenTransform[i]);		
		}
		for (int i = 0; i < childrenTransform.Length; i++) {
			//ReplaceIfOutOfBound(childrenTransform[i]);	
		}
	}

	private void ReplaceIfOutOfBound(Transform transform) {
		if (transform.position.x <= -screenWidth) {
			transform.position = new Vector3(
				(childrenTransform.Length - 1) * screenWidth, transform.position.y);
		}
	}

	private float CalculateScreenWidth() {
		float height = 2 * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		return width;
	}

	private void PreplaceFloorObjects() {
		for (int i = 0; i < childrenTransform.Length; i++) {
			childrenTransform[i].position = new Vector3(
				(i - 1) * screenWidth, transform.position.y);
		}
	}

	private void Move(Transform transform) {
		transform.position = transform.position + new Vector3(-scrollSpeed, 0);
	}

}
