using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	void Update () {
		transform.position = new Vector3 (player.position.x + 6, 6.6f, -5.64f); //Camera Coordinates
	}
}
