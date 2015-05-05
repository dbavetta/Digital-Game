using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if (PlayerPrefs.HasKey ("Highscore_L1") == false) {
			PlayerPrefs.SetInt ("Highscore_L1", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L2") == false) {
			PlayerPrefs.SetInt ("Highscore_L2", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L3") == false) {
			PlayerPrefs.SetInt ("Highscore_L3", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L4") == false) {
			PlayerPrefs.SetInt ("Highscore_L4", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L5") == false) {
			PlayerPrefs.SetInt ("Highscore_L5", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L6") == false) {
			PlayerPrefs.SetInt ("Highscore_L6", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L7") == false) {
			PlayerPrefs.SetInt ("Highscore_L7", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L8") == false) {
			PlayerPrefs.SetInt ("Highscore_L8", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L9") == false) {
			PlayerPrefs.SetInt ("Highscore_L9", 0);
		}




	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CalculateHighscore(int levelnumber, int distance, int coins, int health_remaining){

		int Score = distance + (coins * 5) + (health_remaining * 10);

		switch (levelnumber) {
		case 1:
			if(Score > PlayerPrefs.GetInt("Highscore_L1")){
				PlayerPrefs.SetInt ("Highscore_L1", Score);} 
			break;
		case 2:
			if(Score > PlayerPrefs.GetInt("Highscore_L2")){
				PlayerPrefs.SetInt ("Highscore_L2", Score);} 
			break;
		case 3:
			if(Score > PlayerPrefs.GetInt("Highscore_L3")){
				PlayerPrefs.SetInt ("Highscore_L3", Score);} 
			break;
		case 4:
			if(Score > PlayerPrefs.GetInt("Highscore_L4")){
				PlayerPrefs.SetInt ("Highscore_L4", Score);} 
			break;
		case 5:
			if(Score > PlayerPrefs.GetInt("Highscore_L5")){
				PlayerPrefs.SetInt ("Highscore_L5", Score);} 
			break;
		case 6:
			if(Score > PlayerPrefs.GetInt("Highscore_L6")){
				PlayerPrefs.SetInt ("Highscore_L6", Score);} 
			break;
		case 7:
			if(Score > PlayerPrefs.GetInt("Highscore_L7")){
				PlayerPrefs.SetInt ("Highscore_L1", Score);} 
			break;
		case 8:
			if(Score > PlayerPrefs.GetInt("Highscore_L8")){
				PlayerPrefs.SetInt ("Highscore_L8", Score);} 
			break;
		case 9:
			if(Score > PlayerPrefs.GetInt("Highscore_L9")){
				PlayerPrefs.SetInt ("Highscore_L9", Score);} 
			break;
		}
	}

}
