using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float entityHealth=1F;

	public void takeDamage(float damage){


		entityHealth-=damage;

		if(entityHealth<=0){
			DestroyObject();
		}
	}
	public void DestroyObject(){
		Destroy(gameObject);
	}
}
