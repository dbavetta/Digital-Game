using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {
	public float trapSpeed = 5;
	private Vector3 currentPosition;
	private float spikeYposUp = 0.1f;
	private float spikeYposDown = -0.5f;
	private bool isUp = true;
	private bool moveUp;
	private bool moveDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		InitSpikes ();
		MoveSpikes ();
	}

	void InitSpikes(){

		if (isUp) { //Spikes are UP
			//Debug.Log("Moving down...");
			moveDown = true; //Sets move down as objective 
			moveUp = false; //Disables the option to move up
		}
		else if (!isUp){ //Spikes are DOWN
			//Debug.Log("Moving up...)");
			moveUp = true; //Sets move up as objective
			moveDown = false; //Disables the option to move down
		}
	}

	void MoveSpikes(){

		float step = trapSpeed * Time.deltaTime;
		currentPosition.y = transform.position.y;
		if (moveUp) {
			//Move the spikes up
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, spikeYposUp, transform.position.z), step);
			
			//Checks if the spikes are fully in the up position
			if (currentPosition.y == (spikeYposUp)){ 
				//Debug.Log(isUp);
				isUp = true;
				moveUp = false; //Spikes are fully up
			}
		} else if (moveDown) {
			//Move move the spikes down
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, spikeYposDown, transform.position.z), step);
			
			//Checks if the spikes are fully in the down position
			if(currentPosition.y == (spikeYposDown)){ 
				//Debug.Log(isUp);
				isUp = false;
				moveDown = false; //Spikes are fully down
			}
		}
	}
}
