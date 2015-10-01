using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	public float fadeTime;
	private bool sceneStarting = true;
	private Image myPanel;
	private Color currentColor = Color.black;

	void Start(){
		myPanel = GetComponent<Image>();
	}
	void Update () {
		if (sceneStarting){
			StartScene();
		}
	}

	void FadeToClear(){
		float alphaChange = Time.deltaTime / fadeTime;
		currentColor.a -= alphaChange;
		myPanel.color = currentColor;
	}
	void FadeToBlack(){

	}

	void StartScene(){
		FadeToClear();
		if (myPanel.color.a <=0.05f){
			myPanel.color = Color.clear;
			myPanel.enabled=false;
			sceneStarting=false;
		}
	}
	public void EndScene(string levelName){
		myPanel.enabled=false;
		FadeToBlack();
		if (myPanel.color.a >=0.95f){
			Application.LoadLevel(levelName);
		
		}
	}
}
