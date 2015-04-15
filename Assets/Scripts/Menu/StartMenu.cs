﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	GameObject StartPanel;
	GameObject InstructionPanel;
	GameObject LoadingScreenPanel;
	GameObject StagePanel;
	Animator anim;
	int levelSelected;
	// Use this for initialization
	void Start() 
	{
		Time.timeScale = 1;

		StartPanel = GameObject.Find("Start Panel");
		InstructionPanel = GameObject.Find("Instruction Panel");
		LoadingScreenPanel = GameObject.Find("Loading Screen Panel");
		StagePanel = GameObject.Find("Stage Panels");
		anim = GetComponent<Animator>();
		LoadingScreenPanel.SetActive(false);
		InstructionPanel.SetActive(false);
		StartPanel.SetActive(true);
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
	public void startTutorial()
	{
		StagePanel.SetActive(false);
		LoadingScreenPanel.SetActive(true);
		Application.LoadLevel(1);
	}

	public void startStage1()
	{
		StagePanel.SetActive(false);
		LoadingScreenPanel.SetActive(true);
		Application.LoadLevel(2);
	}
	public void startStage2()
	{
		StagePanel.SetActive(false);
		LoadingScreenPanel.SetActive(true);
		Application.LoadLevel(3);
	}
	public void goToStartMenuSlide()
	{
		anim.SetBool("moveRight",false);
		anim.SetBool("moveLeft",true);
	}
}
