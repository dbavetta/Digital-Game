using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	GameObject PauseMenu; 
	GameObject BackToMenuObject;
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

	public void GoToMenu()
	{

		GameObject.Find("BackToMenuValueObject").GetComponent<BackToMenuValue>().MenuValue = 1;

		Application.LoadLevel(0);
	}

}
