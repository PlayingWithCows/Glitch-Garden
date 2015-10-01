using UnityEngine;
using System.Collections;

public class Virgil : MonoBehaviour {
	private Animator animator;
	private Attacker attacker;
	
	void Start () {
		attacker = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D (Collider2D collider) {

		GameObject attackedObject = collider.gameObject;

		if (!attackedObject.GetComponent<Defender>()){
			return;
		}else{
			animator.SetBool("IsAttacking", true);
			attacker.Attack(attackedObject);
		}


	}

}
