using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	GameObject PauseMenu; 
	// Use this for initialization
	void Start () 
	{
		PauseMenu = GameObject.Find("PauseMenu");
		PauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void pause()
	{
		PauseMenu.SetActive(true);
		Time.timeScale = 0;
	}
	public void Continue()
	{
		PauseMenu.SetActive(false);
		Time.timeScale = 1;
	}

}
