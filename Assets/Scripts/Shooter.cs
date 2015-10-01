using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject myObject;
	private Animator animator;
	private Spawner myLaneSpawner;


	void Start(){

		animator = GameObject.FindObjectOfType<Animator>();
		myObject = GameObject.Find("Projectiles");

		if (myObject == null){
			myObject = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}

	void Update(){

		if(AttackerAheadInLane()){
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}

	}

	void SetMyLaneSpawner(){
		Spawner[] allSpawners = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner thisSpawner in allSpawners){
			if(thisSpawner.transform.position.y==transform.position.y){
				myLaneSpawner = thisSpawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in Lane");
	}


	bool AttackerAheadInLane(){

		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		
		foreach (Transform child in myLaneSpawner.transform){
			if (child.transform.position.x > transform.position.x){return true;}
		}
		return false;

	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;

		newProjectile.transform.parent = myObject.transform;
		newProjectile.transform.position = gun.transform.position;
	}

}
