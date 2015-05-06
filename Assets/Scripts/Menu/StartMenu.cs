using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	
	GameObject StartPanel;
	GameObject InstructionPanel;
	GameObject LoadingScreenPanel;
	GameObject StagePanel;
	GameObject StorePanel;
	GameObject OptionsPanel;
	GameObject BackToMenu;
	GameObject CreditsMenu;
	Animator anim;
	int levelSelected;
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(GameObject.Find("BackToMenuValueObject"));
	}
	
	void Start() 
	{
		Time.timeScale = 1;
		
		
		StartPanel = GameObject.Find("Start Panel");
		BackToMenu = GameObject.Find("BackToMenuValueObject");
		InstructionPanel = GameObject.Find("Instruction Panel");
		LoadingScreenPanel = GameObject.Find("Loading Screen Panel");
		StagePanel = GameObject.Find("Stage Panels");
		StorePanel = GameObject.Find("Store Panel");
		OptionsPanel = GameObject.Find("Options Panel");
		CreditsMenu = GameObject.Find ("Credits");
		anim = GetComponent<Animator>();
		
		
		if(GameObject.Find("BackToMenuValueObject").GetComponent<BackToMenuValue>().MenuValue == 1)
		{
			LoadingScreenPanel.SetActive(false);
			StorePanel.SetActive(false);
			InstructionPanel.SetActive(false);
			StartPanel.SetActive(false);
			OptionsPanel.SetActive(false);
			CreditsMenu.SetActive(false);
			StagePanel.SetActive(true);
		}
		else
		{
			StagePanel.SetActive(false);
			StorePanel.SetActive(false);
			LoadingScreenPanel.SetActive(false);
			InstructionPanel.SetActive(false);
			CreditsMenu.SetActive(false);
			OptionsPanel.SetActive(false);
			StartPanel.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		BackToMenu.GetComponent<BackToMenuValue>().CoinValue = PlayerPrefs.GetInt("Coins");
	}
	
	public void goToStageSelect()
	{
		InstructionPanel.SetActive(false);
		CreditsMenu.SetActive(false);
		StartPanel.SetActive(false);
		StagePanel.SetActive(true);
		
	}
	public void goToInstructions()
	{
		StartPanel.SetActive(false);
		StagePanel.SetActive(false);
		OptionsPanel.SetActive (false);
		InstructionPanel.SetActive(true);
		CreditsMenu.SetActive(false);
	}
	
	public void goToStart()
	{
		InstructionPanel.SetActive(false);
		StagePanel.SetActive(false);
		StorePanel.SetActive(false);
		OptionsPanel.SetActive (false);
		CreditsMenu.SetActive(false);
		StartPanel.SetActive(true);
	}
	public void goToStore()
	{
		StartPanel.SetActive(false);
		OptionsPanel.SetActive (false);
		CreditsMenu.SetActive(false);
		StorePanel.SetActive(true);
	}
	public void goToOptions()
	{
		InstructionPanel.SetActive(false);
		StartPanel.SetActive(false);
		StorePanel.SetActive(false);
		CreditsMenu.SetActive(false);
		OptionsPanel.SetActive (true);
	}
	public void goToCredits()
	{
		InstructionPanel.SetActive(false);
		StartPanel.SetActive(false);
		StorePanel.SetActive(false);
		CreditsMenu.SetActive(true);
		OptionsPanel.SetActive (false);
	}
	public void startTutorial()
	{
		StagePanel.SetActive(false);
		OptionsPanel.SetActive (false);
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
	public void startStage3()
	{
		StagePanel.SetActive(false);
		LoadingScreenPanel.SetActive(true);
		Application.LoadLevel(4);
	}
	public void goToStartMenuSlide()
	{
		StartPanel.SetActive(true);
		InstructionPanel.SetActive(false);
		StagePanel.SetActive(false);
		CreditsMenu.SetActive(false);

	}
	public void NewGame(){
		PlayerPrefs.DeleteAll ();
	}
}
