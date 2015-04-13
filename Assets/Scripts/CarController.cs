using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//'X' to SWITCH LANES
//'Space' to JUMP
[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour {
	public Rigidbody rb;
//---------------------------------------	
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

	//Collision Noises
	public AudioSource[] sounds;
	public AudioSource carCrash;
	public AudioSource potHoleCrash;
	public AudioSource buttonPress;

	//Health Reference Object
	GameObject HealthWrenches;
	GameObject EndStagePanel;
//---------------------------------------

	void Start () {
		rb = GetComponent<Rigidbody>();
		sounds = GetComponents<AudioSource>();
		carCrash = sounds[0];
		HealthWrenches = GameObject.Find("Health Wrenches");
		EndStagePanel = GameObject.Find("End Stage Panel");
		EndStagePanel.SetActive(false);
		potHoleCrash = sounds[1];
		buttonPress = sounds [2];
	}
	
	void Update(){

		//FallingSpeed ();

		//InitLaneSwitch ();

		SwitchLanes ();
	}
	
	void FixedUpdate () {
		//JUMP
		if (Input.GetKeyDown(KeyCode.Space) && !inAir)
			Jump();


		
		//MOVE FORWARD by a factor of 'MaxSpeed'
		rb.velocity = new Vector3 (MaxSpeed, rb.velocity.y, rb.velocity.z);
	}

	//Checks which lane the car is in and send the car to the opposite
	public void InitLaneSwitch(){

//		if (Input.GetKeyDown(KeyCode.X) && inRightLane) { //In right lane
//			Debug.Log("Switching to left lane (X)");
//			moveLeft = true; //Sets move left as objective 
//			moveRight = false; //Disables the option to move right
//		}
//		else if (Input.GetKeyDown(KeyCode.X) && !inRightLane){ //In left lane
//			Debug.Log("Switching to right lane (X)");
//			moveRight = true; //Sets move right as objective
//			moveLeft = false; //Disables the option to move left
//		}
		buttonPress.Play ();
		if ( inRightLane) { //In right lane
			Debug.Log("Switching to left lane (X)");
			moveLeft = true; //Sets move left as objective 
			moveRight = false; //Disables the option to move right
		}
		else if ( !inRightLane){ //In left lane
			Debug.Log("Switching to right lane (X)");
			moveRight = true; //Sets move right as objective
			moveLeft = false; //Disables the option to move left
		}
	}

	//Performs the lane switch
	public void SwitchLanes(){

		if (!inAir) {

			//SWITCHES LANES
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

	//Checks if the object is on the ground
	void OnCollisionStay(){

		inAir = false;
		movingDown = false;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Obstacle") {
			Debug.Log ("Hit Obstacle");
			potHoleCrash.Play();
			HealthWrenches.GetComponent<Health>().looseHealth();
			Destroy (collision.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		
		//Ends game if the players hits a destroyer (dies)
		if (other.tag == "Enemy") {
			Debug.Log ("Collide Enemy");
			HealthWrenches.GetComponent<Health> ().looseHealth ();
			Vector3 tempPos = new Vector3 (transform.position.x, transform.position.y - 1.0f, transform.position.z + 2.0f);
			Instantiate (explosion, tempPos, transform.rotation);
			carCrash.Play ();
			Destroy (other.gameObject);
		} else if (other.tag == "Obstacle") {
			HealthWrenches.GetComponent<Health> ().looseHealth ();
			potHoleCrash.Play();
			Debug.Log ("Collide Obstacle");
		} else if (other.tag == "End Stage") {
			EndStagePanel.SetActive (true);
			Time.timeScale = 0;
		}
	}

	public void Jump()
	{
		buttonPress.Play ();
		if (transform.position.y > 0.0f) {
			if (!inAir)
			{
				inAir = true;
				//Jump
				rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			}
		}
		//Check to disallow jumping while in the air
	}
}
