using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	void Update(){
		foreach (GameObject thisAttacker in attackerPrefabArray) {

			if (Time.timeSinceLevelLoad>15){
			if (isTimeToSpawn (thisAttacker)) {
				Spawn(thisAttacker);
			}
			}
		} 
	}

	bool isTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnsPerSecond = 1 / meanSpawnDelay;


		if (Time.deltaTime>meanSpawnDelay){
			Debug.LogWarning ("Spawn rate capped by framerate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		return (Random.value<threshold);




	}

	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

}
