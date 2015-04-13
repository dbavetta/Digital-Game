using UnityEngine;
using System.Collections;

public class SpawnPiano : MonoBehaviour {

	public int level; //Current game level
	public GameObject piano1; //Prefab you want to fall

	//Lane positions
	private float leftL = 0.3f;
	private float rightL = -1.5f;
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Start()
	{
		if (level == 1) {
			Invoke ("CreatePiano1", 20.5f);
			Invoke ("CreatePiano2", 32.5f);
			Invoke ("CreatePiano3", 42.5f);
		} else if (level == 2) {
			Invoke ("CreatePiano1", 7.5f);
			Invoke ("CreatePiano2", 9.0f);
			Invoke ("CreatePiano3", 24.0f);
			Invoke ("CreatePiano4", 31.0f);
			Invoke ("CreatePiano5", 40.5f);
		}
	}
	
	// Will be called 3 seconds after level start
	void CreatePiano1()
	{
		if (level == 1)
			Instantiate (piano1, new Vector3 (140, 10, rightL), Quaternion.identity);
		else if (level == 2)
			Instantiate (piano1, new Vector3 (60, 10, rightL), Quaternion.identity);
	}
	void CreatePiano2()
	{
		if (level == 1) {
			Instantiate (piano1, new Vector3 (210, 10, rightL), Quaternion.identity);
			Instantiate (piano1, new Vector3 (210, 10, leftL), Quaternion.identity);
		} else if (level == 2) {
			Instantiate (piano1, new Vector3 (70, 10, leftL), Quaternion.identity);
		}
	}
	void CreatePiano3()
	{
		if (level == 1)
			Instantiate(piano1, new Vector3(270, 10, leftL), Quaternion.identity);
		else if (level == 2)
			Instantiate(piano1, new Vector3(160, 10, rightL), Quaternion.identity);
	}
	void CreatePiano4()
	{
		if (level == 1) {
			//Instantiate(piano1, new Vector3(270, 10, leftL), Quaternion.identity);
		}
		else if (level == 2){
			Instantiate(piano1, new Vector3(200, 10, rightL), Quaternion.identity);
			Instantiate(piano1, new Vector3(200, 10, leftL), Quaternion.identity);
		}
	}
	void CreatePiano5()
	{
		if (level == 1) {
			//Instantiate(piano1, new Vector3(270, 10, leftL), Quaternion.identity);
		}
		else if (level == 2){
			Instantiate(piano1, new Vector3(260, 10, leftL), Quaternion.identity);
		}
	}
}
