using UnityEngine;
using System.Collections;

public class BackToMenuValue : MonoBehaviour {
	public int MenuValue = 0;
	public int CoinValue;
	public bool[] boughtCar;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i <= boughtCar.Length; i++)
		{
			boughtCar[i] = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CoinValue = PlayerPrefs.GetInt("Coins");
	}
}
