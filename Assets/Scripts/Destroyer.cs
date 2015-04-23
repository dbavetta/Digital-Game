using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	GameObject HealthWrenches;

	void OnTriggerEnter(Collider other){
		
		//Ends game if the players hits a destroyer (dies)
		if (other.tag == "Player") {
			HealthWrenches = GameObject.Find("Health Wrenches");

			for (int i = 0; i <= HealthWrenches.GetComponent<Health>().HealthImage.Length; i++)
			{
				HealthWrenches.GetComponent<Health>().looseHealth();
			}

//			GameObject EndStagePanel = GameObject.Find("End Stage Panel");
//			EndStagePanel.SetActive (true);
//			Time.timeScale = 0;
			return;
		}
		
		//Destroyes eveything else
//			if (other.gameObject.transform.parent) {
//				Debug.Log ("Collide Parent");
//				Destroy (other.gameObject.transform.parent.gameObject);
//			} 
//			else {
//				Debug.Log ("Collide Object");
//				Destroy(other.gameObject);
//			}
	}

	//Destroys on road obstacles (non triggers)
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Obstacle") {
			Debug.Log ("Hit Obstacle");
			//Play collision sound here
			//Play animation here
			Destroy (this.gameObject);
		}
	}
}
