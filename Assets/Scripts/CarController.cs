using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//'X' to SWITCH LANES
//'Space' to JUMP
[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour {
	public Rigidbody rb;
//---------------------------------------	
	public GameObject piano;
	//Coordinates
	public float LeftLaneZ = 0.3f;
	public float RightLaneZ = -2.0f;

	//Speed Variables
	public float MaxSpeed = 6.0f;
	
	//Jumping Variables
	public float jumpForce = 6;
	public float FallSpeed = 5;
	private bool inAir = false;
	private Vector3 lastAirPosition;
	private bool movingDown = false;
	
	//Lane Switching Variables
	public float LaneSwitchSpeed = 5;
	private Vector3 currentPosition;
	private bool inRightLane = true;
	private bool moveLeft;
	private bool moveRight;

	//Explosion Effect
	public GameObject explosion;

	//Sound effects
	//public AudioSource[] sounds;
	public AudioSource carCrash;
	public AudioSource potHoleCrash;
	public AudioSource buttonPress;
	public AudioSource pickUpCoin;

	//Health Reference Object
	GameObject HealthWrenches;
	public GameObject EndStagePanel;
	public GameObject EndStageTextWin;
	public GameObject EndStageTextLose;

	//Other Reference Objects
	GameObject BackToMenu;

	//Coin Varibales
	public static int Coins;
	Text GUICoins;
	public Text lvlCoins;
	public Text totalCoins;

	public Text Level_Score;
	public Text High_Score;

	private int currentScore = 0;
	private int crashes = 0;

	private int levelDistance = 0; //distance reached by car during level

//---------------------------------------

	void Awake () {
		if (PlayerPrefs.HasKey ("Highscore_L1") == false) {
			PlayerPrefs.SetInt ("Highscore_L1", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L2") == false) {
			PlayerPrefs.SetInt ("Highscore_L2", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L3") == false) {
			PlayerPrefs.SetInt ("Highscore_L3", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L4") == false) {
			PlayerPrefs.SetInt ("Highscore_L4", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L5") == false) {
			PlayerPrefs.SetInt ("Highscore_L5", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L6") == false) {
			PlayerPrefs.SetInt ("Highscore_L6", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L7") == false) {
			PlayerPrefs.SetInt ("Highscore_L7", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L8") == false) {
			PlayerPrefs.SetInt ("Highscore_L8", 0);
		}
		if (PlayerPrefs.HasKey ("Highscore_L9") == false) {
			PlayerPrefs.SetInt ("Highscore_L9", 0);
		}
	}
	
	void Start () {
		HealthWrenches = GameObject.Find("Health Wrenches");
		EndStagePanel = GameObject.Find("End Stage Panel");
		EndStageTextWin = GameObject.Find("You Win");
		EndStageTextLose = GameObject.Find("You Lose");
		GUICoins = GameObject.Find("Coin Count").GetComponent<Text>();
		lvlCoins = GameObject.Find("LevelCoins").GetComponent<Text>();
		totalCoins = GameObject.Find("TotalCoins").GetComponent<Text>();
		Level_Score = GameObject.Find("LevelScore").GetComponent<Text>();
		High_Score = GameObject.Find("HighScore").GetComponent<Text>();
		BackToMenu = GameObject.Find("BackToMenuValueObject");

		EndStagePanel.SetActive(false);
		EndStageTextWin.SetActive(false);	
		EndStageTextLose.SetActive(false);

		GUICoins.text = ": " + Coins;
		rb = GetComponent<Rigidbody>();
		Coins = 0;
		crashes = 0;

		carCrash.volume = PlayerPrefs.GetFloat ("SfxVolume");
		potHoleCrash.volume = PlayerPrefs.GetFloat ("SfxVolume");
		pickUpCoin.volume = PlayerPrefs.GetFloat ("SfxVolume");
		buttonPress.volume = PlayerPrefs.GetFloat ("SfxVolume");

		//Resets these each time the level is loaded
		PlayerPrefs.SetInt ("EndCarPositionOnLevel", 0);
		PlayerPrefs.SetInt ("CoinsForScore", 0);
		PlayerPrefs.SetInt ("HealthRemainingForScore", 0);

		int car = PlayerPrefs.GetInt("CurrentCar");
		switch(car){
		case 1:
			MaxSpeed = 6;
			jumpForce = 6.5f;
			break;
		case 2:
			//coupe
			jumpForce = 7;
			MaxSpeed = 5.7f;
			break;
		case 3:
			//sport
			jumpForce = 6.5f;
			MaxSpeed = 6;
			break;
		default:
			break;	
		}//end switch
	}
	
	void Update(){
		
		GUICoins.text = ": " + Coins;
		BackToMenu.GetComponent<BackToMenuValue>().CoinValue = PlayerPrefs.GetInt("Coins"); //Something wrong with this
		//FallingSpeed ();
		//InitLaneSwitch ();
		SwitchLanes ();

		levelDistance = (int)transform.position.x;
		//Health healthRemaining = GetComponent<Health> ();
		//int hr = healthRemaining.GetHealth ();
		currentScore = (levelDistance + (Coins * 5) + ((5 - crashes) * 10));
		GetHighScore();
		string tempScoreName = "Highscore_L" + (Application.loadedLevel-1); //Dynamically gets level name
		Level_Score.text = "Level Score: " + currentScore;
		High_Score.text = "High Score: " + PlayerPrefs.GetInt(tempScoreName);
	}
	
	void FixedUpdate () {

		if (Input.GetKeyDown(KeyCode.Space) && !inAir)
			Jump();

		//MOVE FORWARD by a factor of 'MaxSpeed'
		rb.velocity = new Vector3 (MaxSpeed, rb.velocity.y, rb.velocity.z);
	}

	//Checks which lane the car is in and send the car to the opposite
	public void InitLaneSwitch(){

		buttonPress.Play ();
		if ( inRightLane) { //In right lane
			//Debug.Log("Switching to left lane (X)");
			moveLeft = true; //Sets move left as objective 
			moveRight = false; //Disables the option to move right
		}
		else if ( !inRightLane){ //In left lane
			//Debug.Log("Switching to right lane (X)");
			moveRight = true; //Sets move right as objective
			moveLeft = false; //Disables the option to move left
		}
	}

	//Performs the lane switch
	public void SwitchLanes(){

		if (!inAir) {
			float step = LaneSwitchSpeed * Time.deltaTime;
			currentPosition.z = transform.position.z;
			if (moveRight) {
				//Move towards right lane
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, transform.position.y, RightLaneZ), step);
				
				//Checks if the car has made it to the right lane
				if (currentPosition.z < (RightLaneZ + 0.1)){ // -2.0 is z coordinate for the right lane (+ 0.1 aded to fix bug)
					inRightLane = true;
					moveRight = false; //Right lane reached
				}
			} else if (moveLeft) {
				//Move towards left lane
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x, transform.position.y, LeftLaneZ), step);
				
				//Checks if the car has made it to the left lane
				if(currentPosition.z > (LeftLaneZ - 0.1)){ // 0.3 is z coordinate for the left lane (- 0.1 aded to fix bug)
					inRightLane = false;
					moveLeft = false; //Left lane reached
				}
			}
		}
	}

	public void Jump(){

		buttonPress.Play ();
		if (inAir == false){

			inAir = true;
			rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			//Debug.Log("Jmp: " + inAir);
		}
	}

	//Applies downforce so the the car will fall faster
	void FallingSpeed(){
	
		//If the cars last position in the air is greater than its current position that means that the car is falling
		//When the computer finds the falling point this function applies downward force to make the car fall faster.
		if( inAir && !movingDown && lastAirPosition.y > transform.position.y ){
			Debug.Log ("Applied down force");
			rb.velocity = new Vector3 (rb.velocity.x, -FallSpeed, rb.velocity.z);
			movingDown = true; //Makes it so that the force is only applied once
		}
		
		lastAirPosition = transform.position;
	}
	
	//Handles All Collisions
	void OnTriggerEnter(Collider other){
		
		//Hits Car
		if (other.tag == "Enemy") {
			Debug.Log ("Collide Enemy");
			crashes++;
			HealthWrenches.GetComponent<Health> ().looseHealth ();
			Vector3 tempPos = new Vector3 (transform.position.x, transform.position.y - 1.0f, transform.position.z + 2.0f);
			GameObject clone = (GameObject)Instantiate (explosion, tempPos, transform.rotation);
			Destroy (clone, 2.5f);
			carCrash.Play ();
			Destroy (other.gameObject);
			GetHighScore();
			//Hits Pothole or piano
		} else if (other.tag == "Obstacle") {
			crashes++;
			HealthWrenches.GetComponent<Health> ().looseHealth ();
			potHoleCrash.Play ();
			Debug.Log ("Collide Obstacle");
			GetHighScore();
			//Hits coin
		} else if (other.tag == "Coin") {
			Debug.Log ("Coin hit");
			pickUpCoin.Play ();
			Coins++;
			SaveCoins ();
			Destroy (other.gameObject);
			GetHighScore();
			//Reaches the end of the level
		} else if (other.tag == "Stage End") {
			Debug.Log("hit end");
			//Sets coin values
			SaveCoins ();
			int LevelCoins = CarController.Coins; //Coins obtained from current level
			int TotalCoinsSaved = PlayerPrefs.GetInt ("Coins"); //All previously obtained coins

			GetHighScore();

			//UI Labels
			EndStagePanel.SetActive(true);
			EndStageTextWin.SetActive(true);
			lvlCoins.enabled = true;
			totalCoins.enabled = true;
			lvlCoins.text = "Coins Obtained: " + LevelCoins;
			totalCoins.text = "Total Coins: " + TotalCoinsSaved;

			string tempScoreName = "Highscore_L" + (Application.loadedLevel-1); //Dynamically gets level name
			Level_Score.text = "Level Score: " + currentScore;
			High_Score.text = "High Score: " + PlayerPrefs.GetInt(tempScoreName);

			Time.timeScale = 0;
		//Spawns pianos 
		} else if (other.tag == "Piano Collider Left") {
			Instantiate (piano, new Vector3 (transform.position.x + 15.0f, 10.0f, 0.3f), Quaternion.identity);
			Debug.Log ("Collide Obstacle");
		} else if (other.tag == "Piano Collider Right") {
			Instantiate (piano, new Vector3 (transform.position.x + 15.0f, 10.0f, -1.5f), Quaternion.identity);
			Debug.Log ("Collide Obstacle");
		} else if (other.tag == "Piano Collider Both") {
			Instantiate (piano, new Vector3 (transform.position.x + 15.0f, 10.0f, 0.3f), Quaternion.identity);
			Instantiate (piano, new Vector3 (transform.position.x + 15.0f, 10.0f, -1.5f), Quaternion.identity);
			Debug.Log ("Collide Obstacle");
		}
}

//Saves all obtained coins
	void SaveCoins(){

		//Saves the overall coin count in memory
		if (PlayerPrefs.HasKey("Coins") == false) {
			PlayerPrefs.SetInt ("Coins", Coins);
		}else{
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Coins); 
		}
	}

	//Checks if the object is on the ground
	void OnCollisionStay(Collision other){

		if (other.gameObject.tag == "ground") {
			inAir = false;
			movingDown = false;
		}
		//Debug.Log ("Coll2: " + inAir);

	}

	public void DeleteCoins(){
		Debug.Log ("Before: " + PlayerPrefs.GetInt("Coins"));
		PlayerPrefs.DeleteKey("Coins");
		Debug.Log ("After: " + PlayerPrefs.GetInt("Coins"));
	}

	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "Obstacle") {
			Debug.Log ("Hit Obstacle");
			potHoleCrash.Play();
			HealthWrenches.GetComponent<Health>().looseHealth();
			Destroy (collision.gameObject);
		}
	}

	public void GetHighScore(){
	
		//Coins
		int currentLevel = (Application.loadedLevel) -1;
		//levelDistance
		//int healthRemaining = GetComponent<Health> ().GetHealth();
		CalculateHighscore(currentLevel, levelDistance, Coins, (5 - crashes));
	}

	public void CalculateHighscore(int levelnumber, int distance, int coins, int health_remaining){
		
		int Score = distance + (coins * 5) + (health_remaining * 10);
		
		switch (levelnumber) {
		case 1:
			if(Score > PlayerPrefs.GetInt("Highscore_L1")){
				PlayerPrefs.SetInt ("Highscore_L1", Score);} 
			break;
		case 2:
			if(Score > PlayerPrefs.GetInt("Highscore_L2")){
				PlayerPrefs.SetInt ("Highscore_L2", Score);} 
			break;
		case 3:
			if(Score > PlayerPrefs.GetInt("Highscore_L3")){
				PlayerPrefs.SetInt ("Highscore_L3", Score);} 
			break;
		case 4:
			if(Score > PlayerPrefs.GetInt("Highscore_L4")){
				PlayerPrefs.SetInt ("Highscore_L4", Score);} 
			break;
		case 5:
			if(Score > PlayerPrefs.GetInt("Highscore_L5")){
				PlayerPrefs.SetInt ("Highscore_L5", Score);} 
			break;
		case 6:
			if(Score > PlayerPrefs.GetInt("Highscore_L6")){
				PlayerPrefs.SetInt ("Highscore_L6", Score);} 
			break;
		case 7:
			if(Score > PlayerPrefs.GetInt("Highscore_L7")){
				PlayerPrefs.SetInt ("Highscore_L1", Score);} 
			break;
		case 8:
			if(Score > PlayerPrefs.GetInt("Highscore_L8")){
				PlayerPrefs.SetInt ("Highscore_L8", Score);} 
			break;
		case 9:
			if(Score > PlayerPrefs.GetInt("Highscore_L9")){
				PlayerPrefs.SetInt ("Highscore_L9", Score);} 
			break;
		}
	}
}
