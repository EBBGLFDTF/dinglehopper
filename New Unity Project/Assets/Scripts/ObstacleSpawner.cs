using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public int spawnRate;
	private int spawnTimer;

	private static int BASE_SPAWN_RATE = 100;

	private void Start() {
		spawnTimer = GameManager.Points / spawnRate;
	}

	void Update() {
		if (spawnTimer-- == 0) {
			SpawnObject();
			NewSpawnTimer();	
		}
	}

	private void NewSpawnTimer() {
		int randomInt = (int)(Random.value * spawnRate) + 1;
		spawnTimer = BASE_SPAWN_RATE / randomInt + 
			BASE_SPAWN_RATE / spawnRate;
	}

	private void SpawnObject() {
		GameObject objectToSpawn = 
			ObstaclePool.Instance(ObjectNames.Obstacle1);
		objectToSpawn.transform.position = Vector3.right * 5;
	}
}
