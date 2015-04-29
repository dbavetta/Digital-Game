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
		EndStagePanel = GameObject.Find("End Stage Panel");
		EndStagePanel = GameObject.Find("End Stage Panel");
		EndStageTextWin = GameObject.Find("You Win");
		//lvlCoins = GameObject.Find("LevelCoins").GetComponent<Text>();
		//totalCoins = GameObject.Find("TotalCoins").GetComponent<Text>();
		healthCount = HealthImage.Length;
		


		//lvlCoins.enabled = false;
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
			GameObject.Find("Car Object").GetComponent<CarController>(). EndStageTextLose.SetActive(true);
			GameObject.Find("Car Object").GetComponent<CarController>().lvlCoins.enabled = true;
			GameObject.Find("Car Object").GetComponent<CarController>().totalCoins.enabled = true;
			int coins = CarController.Coins;
			GameObject.Find("Car Object").GetComponent<CarController>().lvlCoins.text = "Coins Obtained : " + coins;
			GameObject.Find("Car Object").GetComponent<CarController>().totalCoins.text = "Total Coins: " + PlayerPrefs.GetInt("Coins");
			Time.timeScale = 0;
		}
	}
}
