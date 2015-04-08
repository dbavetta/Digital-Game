using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	public Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider coll){
		
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Hit area");
			rb.useGravity = true;
		}
	}
}
