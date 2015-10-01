using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {
	private int levelScore;
	public int levelNumber=1;

	private Transform nogger1, nogger2, nogger3;
//	private GameObject[] NoggerArray;
//	private GameObject thisLevel;
	// Use this for initialization
	void Start () {
	
		DecideIfButtonIsActive();

		foreach (Transform child in transform){
			if (child.CompareTag("Nogger")){
				child.GetComponent<RawImage>().color = Color.black;
			}
			switch (child.name)
			{
			case "Nogger1":
				nogger1 = child;
				break;

			case "Nogger2":
				nogger2 = child;
				break;

			case "Nogger3":
				nogger3 = child;
				break;
			}

		}

		Debug.Log (PlayerPrefsManager.GetLevelScore(1));
		Debug.Log (PlayerPrefsManager.GetLevelScore(2));
		Debug.Log (PlayerPrefsManager.GetLevelScore(3));

		GetScoreNoggers(levelNumber);

//		GetComponent<SpriteRenderer>().color = Color.white;

	}

	void DecideIfButtonIsActive ()
	{
		if(levelNumber>=2){

		switch (PlayerPrefsManager.IsLevelUnlocked(levelNumber))
		{
		case true:
			GetComponent<Button>().enabled = true;
			break;

		case false:
				GetComponent<Button>().enabled = false;
			break;
		}
		}else {GetComponent<Button>().enabled = true;}

	}

	void GetScoreNoggers(int levelNumber){

		int levelScore = PlayerPrefsManager.GetLevelScore(levelNumber);
		switch (levelScore){
		case 0: 
			break;
		case 1: 
			nogger1.GetComponent<RawImage>().color = Color.yellow;
			break;
		case 2:
			nogger1.GetComponent<RawImage>().color = Color.yellow;
			nogger2.GetComponent<RawImage>().color = Color.yellow;
			break;
		case 3:
			nogger1.GetComponent<RawImage>().color = Color.yellow;
			nogger2.GetComponent<RawImage>().color = Color.yellow;
			nogger3.GetComponent<RawImage>().color = Color.yellow;
			break;
		}

	}
	// Update is called once per frame

}
