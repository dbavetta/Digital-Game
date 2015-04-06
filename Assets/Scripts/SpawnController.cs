using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject[] obj;
	public float spawnInterval = 1f;
	
	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	void Spawn(){
		
		Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
		Invoke ("Spawn", spawnInterval);
	}
}
