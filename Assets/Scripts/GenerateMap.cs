using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour {

	public int[] tileSequence;
	public GameObject background;
	public GameObject pianoColliderLeft;
	public GameObject pianoColliderRight;
	public GameObject pianoColliderBoth;
	public GameObject road;
	public GameObject potHoleL;
	public GameObject potHoleR;
	public GameObject enemyL;
	public GameObject enemyR;
	public GameObject bottomless;
	
	List<int> pianoPos = new List<int>();
	List<int> pianolane = new List<int>();
	float leftL = 0.3f;
	float rightL = -1.5f;
	int currentPos = 0;
	float currentBGpos = 0.0f;
	int i = 0;

	// Use this for initialization
	void Start () {

		GenerateMapTiles ();
		GenerateBG ();
	}
	
	// Update is called once per frame
	void LateUpdate () {

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
				default:
					break;

			}
		}
	}

	void GenerateBG(){
		for (int i = 0; i < tileSequence.Length; ++i) {
			Instantiate(background, new Vector3( currentBGpos , -0.69f, 3.34f), Quaternion.identity);
			currentBGpos = currentBGpos + 10.0f;
		}
	}


}

