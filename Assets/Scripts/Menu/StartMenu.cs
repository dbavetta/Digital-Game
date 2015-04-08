using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	GameObject StartPanel;
	GameObject InstructionPanel;
	Animator anim;
	int levelSelected;
	// Use this for initialization
	void Start () 
	{
		StartPanel = GameObject.Find("Start Panel");
		InstructionPanel = GameObject.Find("Instruction Panel");
		anim = GetComponent<Animator>();
		InstructionPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void goToStageSelect()
	{
		anim.SetBool("moveLeft",false);
		anim.SetBool("moveRight",true);

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
	public void startGame()
	{
		Application.LoadLevel(1);
	}
	public void goToStartMenuSlide()
	{
		anim.SetBool("moveRight",false);
		anim.SetBool("moveLeft",true);
	}
}
