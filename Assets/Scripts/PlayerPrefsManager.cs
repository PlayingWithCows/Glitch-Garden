using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	const string LEVELSCORE = "level_score_";


	public static void SetMasterVolume(float volume){

		if (volume>=0f && volume <= 1f){
		PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}else{
			Debug.LogError("Master volume out of range");}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}


	public static void UnlockLevel (int level) {

		if (level<= Application.levelCount-1){

			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1);

		}else{
			Debug.LogError("level not in build order");
		}

	}

	public static bool IsLevelUnlocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue==1);

		if (level<= Application.levelCount-1){
				return isLevelUnlocked;
				}else{

			Debug.LogError("level not in build order");
			return false;
		}


	}

	public static void SetLevelScore(int levelNumber, int score){
		
		if (score>=0 && score <= 3 && (GetLevelScore(levelNumber)<score )){
			PlayerPrefs.SetInt (LEVELSCORE + levelNumber.ToString(), score);
		}else{
			Debug.LogError("Level Score Out of Range");}
	}
	
	public static int GetLevelScore(int level){
		return PlayerPrefs.GetInt(LEVELSCORE+ level.ToString());
	}



	public static void SetDifficulty (float difficulty){
		if (difficulty>=1 && difficulty <= 3){
		PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		}else{
			Debug.LogError("difficulty out of range");}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}


}