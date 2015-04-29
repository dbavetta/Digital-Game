using UnityEngine;
using System.Collections;

public class LoadCar : MonoBehaviour {
	GameObject sport;
	GameObject coupe;
	GameObject truck;

	void Start(){
		//PlayerPrefs.DeleteKey ("CurrentCar"); //For debugging
		sport = GameObject.Find("Sport");
		coupe = GameObject.Find("Coupe");
		truck = GameObject.Find("Truck");
		
		//Saves the overall coin count in memory
		if (!PlayerPrefs.HasKey("CurrentCar")) {
			Debug.Log("create car");
			PlayerPrefs.SetInt ("CurrentCar", 1);
			truck.SetActive(true);  //1
			coupe.SetActive(false); //2
			sport.SetActive(false); //3
			
		}else{
			Debug.Log("load car");
			int car = PlayerPrefs.GetInt("CurrentCar");
			Debug.Log(car);
			switch(car){
			case 1:
				truck.SetActive(true);
				coupe.SetActive(false); 
				sport.SetActive(false);
				break;
			case 2:
				truck.SetActive(false);
				coupe.SetActive(true);
				sport.SetActive(false);
				break;
			case 3:
				truck.SetActive(false);
				coupe.SetActive(false);
				sport.SetActive(true);
				break;
			default:
				truck.SetActive(true);
				coupe.SetActive(false);
				sport.SetActive(false);
				break;	
			}//end switch
			
		}//end else
	}
}
