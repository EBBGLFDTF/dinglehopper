using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFloor : MonoBehaviour{

	public static float scrollSpeed = 0.1f;

	private Transform[] childrenTransform;

	private float screenWidth;

	private void Awake() {
		childrenTransform = GetAllChildrenTransform(); 
		screenWidth = CalculateScreenWidth();
		PreplaceFloorObjects();					
	}

	void Update() {
		for (int i = 0; i < childrenTransform.Length; i++) {
			Move(childrenTransform[i]);		
		}
		for (int i = 0; i < childrenTransform.Length; i++) {
			ReplaceIfOutOfBound(childrenTransform[i]);	
		}
	}

	private Transform[] GetAllChildrenTransform() {
		int numChildren = transform.childCount;
		Transform[] children = new Transform[numChildren];
		for (int i = 0; i < numChildren; i++) {
			children[i] = transform.GetChild(i);
		}

		return children;
	}

	private void ReplaceIfOutOfBound(Transform t) {
		if (t.position.x <= -screenWidth) {
			t.position = new Vector3(
				(childrenTransform.Length - 1) * screenWidth, t.position.y);
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
				i * screenWidth, childrenTransform[i].position.y);
		}
	}

	private void Move(Transform transform) {
		transform.position = transform.position + new Vector3(-scrollSpeed, 0);
	}

}
