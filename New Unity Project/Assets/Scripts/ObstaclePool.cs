using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectNames {
	Obstacle1, Obstacle2, Obstacle3, Obstacle4
}

public class ObstaclePool : MonoBehaviour {

	public static ObstaclePool instance;
	public static int poolSize = 5;

	public static GameObject[,] objectPools;
	public static int[] cycleIndexes;
	public GameObject[] obstacleList;

    void Start() {
		//initialize members
		instance = this;
		objectPools = new GameObject[obstacleList.Length, poolSize];
		cycleIndexes = new int[obstacleList.Length];

		PoolObjects();
    }

	private void PoolObjects() {
		for (int i = 0; i < obstacleList.Length; i++) {
			for (int j = 0; j < poolSize; j++) {
				Debug.Log(j);
				objectPools[i,j] = Instantiate(
					obstacleList[i], 
					new Vector3(), 
					Quaternion.identity);
			}
		}
	}

	public static GameObject Instance(ObjectNames objectName) {
		int objectNameIndex = (int)objectName;
		int objectCycleIndex = cycleIndexes[objectNameIndex];
		GameObject objectToInstance =
			objectPools[objectNameIndex, objectCycleIndex];
		CyclePool(objectName);
		objectToInstance.SetActive(true);
		return objectToInstance; 
	}

	private static void CyclePool(ObjectNames objectName) {
		int newIndex = 	
			cycleIndexes[(int)objectName] + 1;
		cycleIndexes[(int)objectName] = newIndex;
		if (cycleIndexes[(int)objectName] == poolSize) {
			cycleIndexes[(int)objectName] = 0;
		}
	}
}
