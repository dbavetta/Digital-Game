using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour {
	public Image [] HealthImage;
	public int healthCount;

	GameObject EndStagePanel;
	GameObject EndStageTextWin;
	GameObject EndStageTextLose;
	Text lvlCoins;
	Text totalCoins;

	// Use this for initialization
	void Start () 
	{
		EndStageTextWin = GameObject.Find("You Win");
		EndStageTextLose = GameObject.Find("You Lose");
		EndStagePanel = GameObject.Find("End Stage Panel");
		lvlCoins = GameObject.Find("LevelCoins").GetComponent<Text>();
		totalCoins = GameObject.Find("TotalCoins").GetComponent<Text>();
		healthCount = HealthImage.Length;
		
		EndStageTextWin.SetActive(false);	
		EndStageTextLose.SetActive(false);

		//lvlCoins.enabled = false;
	}
	void Awake()
	{
		DontDestroyOnLoad(GameObject.Find("BackToMenuValueObject"));
	}
	// Update is called once per frame
	void Update () 
	{

	
	}

	public void looseHealth()
	{
		if (healthCount > 0) {
			HealthImage [healthCount - 1].gameObject.SetActive (false);
			healthCount--;
		} 

		if (healthCount == 0)
		{
			EndStagePanel.SetActive(true);
			EndStageTextLose.SetActive(true);
			lvlCoins.enabled = true;
			totalCoins.enabled = true;
			int coins = CarController.Coins;
			lvlCoins.text = "Coins Obtained : " + coins;
			totalCoins.text = "Total Coins: " + PlayerPrefs.GetInt("Coins");
			Time.timeScale = 0;
		}
	}
}
