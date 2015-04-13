using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour {
	public Image [] HealthImage;
	public int healthCount;

	GameObject EndStagePanel;

	// Use this for initialization
	void Start () 
	{
		EndStagePanel = GameObject.Find("End Stage Panel");
		healthCount = HealthImage.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void looseHealth()
	{
		if (healthCount >= 0) {
			HealthImage [healthCount].gameObject.SetActive (false);
			healthCount--;
		} 
	}
}
