using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public float seenEverySecond;

	private Animator animator;
	[Range(-1F,1.5F)]
	private float currentSpeed;
	private GameObject currentTarget;
	private Health health;


	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!currentTarget){
			animator.SetBool("IsAttacking", false);
		}
		transform.Translate (Vector3.left *currentSpeed*Time.deltaTime);

	}


	public void SetSpeed(float speed){
		currentSpeed=speed;
	}

	public void StrikeCurrentTarget(float damage){

		if (currentTarget){
		Health health = currentTarget.GetComponent<Health>();
			if (health){
				health.takeDamage(damage);
			}
		}




	}

	public void Attack(GameObject attackedObject){
		currentTarget = attackedObject;

	}
}
