using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter (Collider other) 
	{
		if(other.tag == "Player")
		{
			rb.useGravity = true;
			//rb.isKinematic = false;
		}
	}
}
