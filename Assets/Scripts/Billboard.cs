using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	
	void Update()
	{
		Quaternion temp = Camera.main.transform.rotation; //faces the camera
		transform.rotation = temp;
	}

}
