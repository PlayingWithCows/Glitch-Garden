using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
	public float levelDuration;

	private AudioSource winSound;
	private Slider slider;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		winSound = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindWinText ();
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad/levelDuration;
		if (Time.timeSinceLevelLoad >= levelDuration && !isEndOfLevel){
//			levelManager.load... winScreen
			HandleWinCondition ();
		}

	}

	void ScoreLevel ()
	{
		int level;
		int score;
		Lives livesScript;
		livesScript = FindObjectOfType<Lives>();

		level = Application.loadedLevel-2;

		score = livesScript.lives;



		PlayerPrefsManager.SetLevelScore(level,score);
		PlayerPrefsManager.UnlockLevel(level+1);
		Debug.Log("setting level score for level " +level+" to " +score);
		Debug.Log (PlayerPrefsManager.GetLevelScore(level));
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects();
		isEndOfLevel = true;
		winSound.Play ();
		winLabel.SetActive (true);
		ScoreLevel();
		Invoke ("LoadNextLevel", winSound.clip.length);



	}

	void DestroyAllTaggedObjects(){
		GameObject[] allObjects;
		allObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject thisObject in allObjects){
			Destroy (thisObject);
		}
	}

	void FindWinText ()
	{
		winLabel = GameObject.Find ("Win");
		if (!winLabel) {
			Debug.Log ("Please Create YouWin Object");
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
