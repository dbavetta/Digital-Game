using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour {
	public Image [] HealthImage;
	public int healthCount;

	GameObject EndStagePanel;
	GameObject EndStageTextWin;
	GameObject EndStageTextLose;

	// Use this for initialization
	void Start () 
	{
		EndStageTextWin = GameObject.Find("You Win");
		EndStageTextLose = GameObject.Find("You Lose");
		EndStagePanel = GameObject.Find("End Stage Panel");
		healthCount = HealthImage.Length;
		
		EndStageTextWin.SetActive(false);	
		EndStageTextLose.SetActive(false);
		EndStagePanel.SetActive(false);
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
		}
	}
}
