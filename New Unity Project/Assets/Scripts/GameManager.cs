using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static float pointIncreaseModifier = 0.01f;

	public static GameManager instance;
	public static GameObject instanceGameObject;

	private static int points;
	private static float speed;

	public static int Points {
		get { return points; }
	} 

	public static float Speed {
		get { return speed; }
	}

	public static GameManager Instance {
		get { return instance; }
	}
	
	public static GameObject InstanceGameObject {
		get { return instanceGameObject; }
	}

	public static void AddPoints(int pointsToAdd) {
		points += pointsToAdd;
	}

	private static void IncreaseSpeed(int pointsAdded) {
		speed += pointsAdded * pointIncreaseModifier;
		
		//update speeds of objects;
	}

	void Start() {
		instance = this;
		instanceGameObject = this.gameObject;
	}

}
