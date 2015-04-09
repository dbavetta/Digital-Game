using UnityEngine;
using System.Collections;

public class SpawnPiano : MonoBehaviour {

	public GameObject piano1;
	
	private bool piano1_spawned = false;

	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Start()
	{
		Invoke("CreatePiano", 20.5f);
		Invoke("CreatePiano2", 32.5f);
		Invoke("CreatePiano3", 42.5f);
	}
	
	// Will be called 3 seconds after level start
	void CreatePiano()
	{
			Instantiate(piano1, new Vector3(140, 10, -1.5f), Quaternion.identity);
	}
	void CreatePiano2()
	{
		Instantiate(piano1, new Vector3(210, 10, -1.5f), Quaternion.identity);
		Instantiate(piano1, new Vector3(210, 10, 0.3f), Quaternion.identity);
	}
	void CreatePiano3()
	{
		Instantiate(piano1, new Vector3(270, 10, 0.3f), Quaternion.identity);
	}
}
