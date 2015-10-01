using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private Lives livesScript;


	void OnTriggerEnter2D (Collider2D collider){
		livesScript = FindObjectOfType<Lives>();

		Destroy (collider.gameObject);
		livesScript.LoseLives();

		}
	}

