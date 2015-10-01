using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
AudioSource worzelSound;

	public int tennerCost = 100;
	public AudioClip exclamation;
	private TennerDisplay tennerDisplay;
	private Animator animator;

	void Start(){
		worzelSound = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		tennerDisplay = GameObject.FindObjectOfType<TennerDisplay>();
	}

	public void AddTenners (int amount){
		tennerDisplay.AddTenners (amount);

	}
	public void PlayWorzelSound(){
		worzelSound.PlayOneShot(exclamation, 0.2f);
	}

	void OnTriggerStay2D (Collider2D attacker){

		if(attacker.GetComponent<Attacker>()){
			animator.SetTrigger("isAttacked");
		}

	}

}
