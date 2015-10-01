using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lives : MonoBehaviour {
	private LevelManager levelManager;
	private Text livesText;
	public int lives=3;
	
	void Start(){
		livesText = GetComponent<Text>();
		UpdateDisplay();
		levelManager = FindObjectOfType<LevelManager>();
	}

	
	public void LoseLives (){

		if (lives>=2){
			lives-=1;
			UpdateDisplay();
		}else{
			levelManager.LoadLevel("03b Lose");
		}
	}
	
	private void UpdateDisplay(){
		livesText.text = lives.ToString();
	}
}