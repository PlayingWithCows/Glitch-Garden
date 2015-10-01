using UnityEngine;
using System.Collections;

public class Neo : MonoBehaviour {
	private Animator animator;
	private Attacker attacker;
	
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D (Collider2D collider) {

		GameObject attackedObject = collider.gameObject;
		
		if (!attackedObject.GetComponent<Defender>()){
			return;
		}
		if (attackedObject.GetComponent<qpt>()){
			animator.SetTrigger("blink");
		}else{
			animator.SetBool("IsAttacking", true);
			attacker.Attack(attackedObject);
		}
		
		
	}
	
}