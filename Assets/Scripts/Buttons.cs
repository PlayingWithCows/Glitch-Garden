using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	private Buttons[] buttonArray;
	private Text costText;

	void Start(){
		buttonArray = GameObject.FindObjectsOfType<Buttons>();

		costText = GetComponentInChildren<Text>();
		if (!costText){Debug.LogWarning(name + " has no cost");}

    	costText.text = defenderPrefab.GetComponent<Defender>().tennerCost.ToString();
		


	}

//	void OnMouseOver(){
//
//	}

	void OnMouseDown(){

		foreach (Buttons thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;

		}

		GetComponent<SpriteRenderer>().color = Color.white;

		selectedDefender=defenderPrefab;
	}
}
