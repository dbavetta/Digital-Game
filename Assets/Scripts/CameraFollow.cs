using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	void Update () {
		transform.position = new Vector3 (player.position.x + 4, 7.5f, -4.3f); //Camera Coordinates
	}
}
