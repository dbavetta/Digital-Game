using UnityEngine;
using System.Collections;

public class BugFix : MonoBehaviour {

	void Awake(){
		GameObject EndStagePanel = GameObject.Find("End Stage Panel");
		EndStagePanel.SetActive (false);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
