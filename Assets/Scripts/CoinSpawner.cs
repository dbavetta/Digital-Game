using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {
	
	public GameObject Coin;
	public int Count;
	public int LevelLength;

	// Use this for initialization
	void Start () {
		SpawnCoins ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnCoins(){

		for (int i = 0; i < Count; ++i){
				
			float lane = Random.Range (0.0f,1.9f);
			float Xpos = Random.Range (0,LevelLength -10);
			
			if(lane < 1)
				lane = 1; //Left lane
			else
				lane = -1.5f; //Right Lane
				
			Instantiate(Coin, new Vector3(Xpos, 0.0f, lane), Quaternion.identity);
		}
			
		//int numCanGen = Count * 10; //each road tile is 10 units long
	}

}
