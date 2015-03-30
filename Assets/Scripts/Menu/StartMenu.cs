using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	GameObject StartPanel;
	GameObject InstructionPanel;
	// Use this for initialization
	void Start () 
	{
		StartPanel = GameObject.Find("Start Panel");
		InstructionPanel = GameObject.Find("Instruction Panel");

		InstructionPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void goToStageSelect()
	{
		Application.LoadLevel(1);
	}
	public void goToInstructions()
	{
		StartPanel.SetActive(false);
		InstructionPanel.SetActive(true);
	}

	public void goToStart()
	{
		InstructionPanel.SetActive(false);
		StartPanel.SetActive(true);
	}
}
