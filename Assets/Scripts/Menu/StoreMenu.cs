using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StoreMenu : MonoBehaviour {
	public Image[] carImages;
	public int cursor;
	public Text CoinText;
	public Text carOnePrice , carTwoPrice;
	public Text priceText;
	bool confrimBox = false;
	public GameObject ConfirmBox;
	public GameObject BoughtBox;
	// Use this for initialization
	void Start () 
	{
		ConfirmBox = GameObject.Find("Confirm Box");
		BoughtBox = GameObject.Find("Bought Box");
		priceText = GameObject.Find("Price Text").GetComponent<Text>();
		CoinText = GameObject.Find("Coin Text").GetComponent<Text>();
		cursor = 0;

		BoughtBox.SetActive(false);
		ConfirmBox.SetActive(false);
		carImages[cursor].enabled = true;
		for(int i = 0; i <= carImages.Length - 1; i++)
		{
			if ( i != cursor)
				carImages[i].enabled = false;
		}


	}
	
	// Update is called once per frame
	void Update () 
	{
		CoinText.text =  GameObject.Find("BackToMenuValueObject").GetComponent<BackToMenuValue>().CoinValue.ToString();
		if(cursor == 0)
		{
			priceText.text = "0";
		}

		if(cursor == 1)
		{
			priceText.text = "5";
		}

		if(cursor == 2)
		{
			priceText.text = "50";
		}
	
	}

	public void moveRight()
	{
		if ( cursor + 1 <= carImages.Length - 1 && confrimBox == false)
		{
			carImages[cursor].enabled = false;
			cursor++;
			carImages[cursor].enabled = true;

		}
		else
		{
			carImages[cursor].enabled = false;
			cursor = 0;
			carImages[cursor].enabled = true;
		}
	}

	public void moveLeft()
	{
		if ( cursor - 1 >= 0 && confrimBox == false)
		{
			carImages[cursor].enabled = false;
			cursor--;
			carImages[cursor].enabled = true;
		}
		else
		{
			carImages[cursor].enabled = false;
			cursor = carImages.Length - 1;
			carImages[cursor].enabled = true;
		}
	}

	public void buyCar()
	{
		if(int.Parse(CoinText.text) - int.Parse(priceText.text)>= 0 && GameObject.Find("BackToMenuValueObject").GetComponent<BackToMenuValue>().boughtCar[cursor] == false )
		{
			ConfirmBox.SetActive(true);
		}
		else if (GameObject.Find("BackToMenuValueObject").GetComponent<BackToMenuValue>().boughtCar[cursor] == true)
		{
			BoughtBox.SetActive(true);
		}
	}

	public void selectNO()
	{
		ConfirmBox.SetActive(false);
	}
	
	public void selectYES()
	{
		ConfirmBox.SetActive(false);
		CoinText.text = (int.Parse(CoinText.text) - int.Parse(priceText.text)).ToString();
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - int.Parse(priceText.text));
		PlayerPrefs.SetInt ("CurrentCar", cursor + 1);
		GameObject.Find("BackToMenuValueObject").GetComponent<BackToMenuValue>().boughtCar[cursor]= true;
	}

	public void selectNOBB()
	{
		BoughtBox.SetActive(false);
	}
	public void selectYESBB()
	{
		PlayerPrefs.SetInt ("CurrentCar", cursor + 1);
		BoughtBox.SetActive(false);
	}
}
