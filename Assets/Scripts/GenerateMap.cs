using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour {

	public bool randomGeneration = false;
	public AudioSource LevelMusic;
	public int[] tileSequence;
	public GameObject vehicle;
	public GameObject background;
	public GameObject pianoColliderLeft;
	public GameObject pianoColliderRight;
	public GameObject pianoColliderBoth;
	public GameObject SpikeL;
	public GameObject SpikeR;
	public GameObject SpikeB;
	public GameObject road;
	public GameObject potHoleL;
	public GameObject potHoleR;
	public GameObject enemyL;
	public GameObject enemyR;
	public GameObject bottomless;

	GameObject jumpButton;
	GameObject switchButton;
	GameObject jumpInv;
	GameObject switchInv;
	
	List<int> pianoPos = new List<int>();
	List<int> pianolane = new List<int>();
	float leftL = 0.3f;
	float rightL = -1.5f;
	int currentPos = 0;
	float currentBGpos = 0.0f;
	int i = 0;

	// Use this for initialization
	void Start () {

		LevelMusic.volume = PlayerPrefs.GetFloat ("MusicVolume");

		jumpButton = GameObject.Find("Jump");
		switchButton = GameObject.Find("Switch");
		jumpInv = GameObject.Find("JumpInverse");
		switchInv = GameObject.Find("SwitchInverse");


		if (PlayerPrefs.GetInt ("InvertControls") == 1) {
			jumpButton.SetActive(false);
			switchButton.SetActive(false);
			jumpInv.SetActive(true);
			switchInv.SetActive(true);
		} else {
			jumpButton.SetActive(true);
			switchButton.SetActive(true);
			jumpInv.SetActive(false);
			switchInv.SetActive(false);
		}

		if (!randomGeneration)
			GenerateMapTiles ();
		else
			GenerateRandom();

		GenerateBG ();
	}
	
	// Update is called once per frame
	void Update () {
		if (randomGeneration && vehicle.transform.position.x > (currentPos - 20)) {
			GenerateRandom();
		}
	}
	
	void GenerateMapTiles(){
		int tile;
		for(int i = 0; i < tileSequence.Length; ++i){
			tile = tileSequence[i];
			switch(tile){
				case 1: //Blank tile
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 2: //Pothole left lane
					Instantiate(potHoleL, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 3: //Pothole right lane
					Instantiate(potHoleR, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 4: //Enemy car left lane
					Instantiate(enemyL, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 5: //Enemy car right lane
					Instantiate(enemyR, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 6: //bottomless pit lane
					Instantiate(bottomless, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 7: //Piano left lane
					Instantiate(pianoColliderLeft, new Vector3( (currentPos - 15.0f) , 0.0f, 0.0f), Quaternion.identity);
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					pianoPos.Add(currentPos);
					pianolane.Add (0);
					currentPos = currentPos + 10;
					break;
				case 8: //Piano right lane
					Instantiate(pianoColliderRight, new Vector3( (currentPos - 15.0f) , 0.0f, 0.0f), Quaternion.identity);
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					pianoPos.Add(currentPos);
					pianolane.Add (1);	
					currentPos = currentPos + 10;
					break;
				case 9: //Piano both lanes
					Instantiate(pianoColliderBoth, new Vector3( (currentPos - 15.0f) , 0.0f, 0.0f), Quaternion.identity);
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 10: //Spike left lane
					Instantiate(SpikeL, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 11: //Spike right lane
					Instantiate(SpikeR, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 12: //Spike both lanes
					Instantiate(SpikeB, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				default:
					break;

			}
		}
	}

	//Spawns 10 tiles at a time
	void GenerateBG(){
		for (int i = 0; i < tileSequence.Length; ++i) {
			Instantiate(background, new Vector3( currentBGpos , -0.69f, 3.34f), Quaternion.identity);
			currentBGpos = currentBGpos + 10.0f;
		}
	}

	void GenerateRandom(){

		for (int i = 0; i < 10; ++i){
			if(i == 0){ //makes sure you dont start off over a bottomless pit
				Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
				currentPos = currentPos + 10;
			} else{
				int tile = Random.Range(0,12);
				
				switch(tile){
				case 1: //Blank tile
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 2: //Pothole left lane
					Instantiate(potHoleL, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 3: //Pothole right lane
					Instantiate(potHoleR, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 4: //Enemy car left lane
					Instantiate(enemyL, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 5: //Enemy car right lane
					Instantiate(enemyR, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 6: //bottomless pit lane
					Instantiate(bottomless, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 7: //Piano left lane
					Instantiate(pianoColliderLeft, new Vector3( (currentPos - 15.0f) , 0.0f, 0.0f), Quaternion.identity);
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					pianoPos.Add(currentPos);
					pianolane.Add (0);
					currentPos = currentPos + 10;
					break;
				case 8: //Piano right lane
					Instantiate(pianoColliderRight, new Vector3( (currentPos - 15.0f) , 0.0f, 0.0f), Quaternion.identity);
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					pianoPos.Add(currentPos);
					pianolane.Add (1);	
					currentPos = currentPos + 10;
					break;
				case 9: //Piano both lanes
					Instantiate(pianoColliderBoth, new Vector3( (currentPos - 15.0f) , 0.0f, 0.0f), Quaternion.identity);
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 10: //Spike left lane
					Instantiate(SpikeL, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 11: //Spike right lane
					Instantiate(SpikeR, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				case 12: //Spike both lanes
					Instantiate(SpikeB, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
				default:
					Instantiate(road, new Vector3(currentPos, 0.0f, 0.0f), Quaternion.identity);
					currentPos = currentPos + 10;
					break;
					
				}
			}
		}
	}	

}	