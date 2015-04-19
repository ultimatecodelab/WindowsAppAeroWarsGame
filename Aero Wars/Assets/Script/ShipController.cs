/* Everything about controlling the ship
 */
using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float horizontalTopSpeed = 0.7f;
	public float verticalTopSpeed = 0.7f;
	public float horizontalSpeedChange=0.6f;
	public float verticalSpeedChange=0.1f;
	private float verticalSpeedV = 0f;
	private  float verticalSpeed=0f;

	private float horizontalSpeedV=0.3f;
//	private  float verticalSpeed=0f;
	private float horizontalSpeed=0f;

	public float maxHorizontalPos = 2f;  

	public float maxVerticalPos = -10f;  
	public float minVerticalPos = -13f; 
	public GameObject mainBullet;
	public int bulletCounter=0;

	public float health=1f;
	
	public float energyHealth=20f;

	public GameObject healthBox;
	public Texture healthTexture;
	public Texture healthBarBackground;
	public Texture energyTexture;
	private float playerBulletDec = 0.3f; //bullet/ammo decrement factor


	public Vector3 spawnValues;
	private float MAX_HEALTH=20f;
	private float MAX_ENERGY=20f;
	public int HEALTH_THREASOLD=6;


	private int isMuted = 0;
	public ParticleEmitter myParticle;


	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	void OnApplicationPause(bool pauseStatus) {
		//Sound settings
		isMuted = PlayerPrefs.GetInt ("isMuted");
		
		if(isMuted == 1){
			AudioListener.pause = true;
		}
		else{
			AudioListener.pause = false;
		}
	}
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		//Checking if the device supports accelerometer of keyboard
		if ((Input.acceleration.x*horizontalTopSpeed >0 ||Input.acceleration.x * horizontalTopSpeed<-0) && Input.touchCount>=0) {
			//verticalSpeed = Mathf.SmoothDamp (verticalSpeed, verticalTopSpeed * Input.acceleration.z, ref verticalSpeedV, verticalSpeedChange);
			horizontalSpeed = Mathf.SmoothDamp (horizontalSpeed, horizontalTopSpeed * Input.acceleration.x, ref horizontalSpeedV, horizontalSpeedChange);
		}
		// if device doesnt support accelerometer 
		else {
			verticalSpeed = Mathf.SmoothDamp (verticalSpeed, verticalTopSpeed * Input.GetAxis ("Vertical"), ref verticalSpeedV,verticalSpeedChange);
			horizontalSpeed = Mathf.SmoothDamp (horizontalSpeed, horizontalTopSpeed * Input.GetAxis ("Horizontal"), ref horizontalSpeedV, horizontalSpeedChange);
		}
		 transform.position = new Vector3 (Mathf.Clamp (transform.position.x + horizontalSpeed,
        -maxHorizontalPos, maxHorizontalPos), transform.position.y,
         Mathf.Clamp (transform.position.z + 
		 verticalSpeed * Time.deltaTime, minVerticalPos, maxVerticalPos));


		//Tap of press space to fire the bullet
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)||Input.GetButtonDown ("Jump"))
		{
			energyHealth -= playerBulletDec; //decrementing the energy

			//availability of the bullet
			if (energyHealth > 1) {
				Instantiate (mainBullet, transform.position + new Vector3 (0f, 0f, 1.2f), transform.rotation);
				audio.Play();
			}
			else{
				energyHealth=0f;
			}

		}
		//player smoke particle activation 
		if (health <=HEALTH_THREASOLD) {
			myParticle.Emit();
		}
		//game over
		if (health <= 0) {
			//Save your settings here... 
			gameOver();
			Application.LoadLevel (2);
		}

	}

	IEnumerator particleWait() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(2);
		Debug.Log("After Waiting 2 Seconds");
	}
	
	//This method is called after the game is over-> Saves player score 
	void gameOver(){
		GameObject playerSc = GameObject.Find("ScoreTxt");
		PlayerScore score = playerSc.GetComponent<PlayerScore>();
		// Get current health
		int tempScore = score.score;
		Debug.Log (tempScore);

		//saving user score
		if (tempScore > PlayerPrefs.GetInt ("HighScore1")) {


			//PlayerPrefs.SetInt("HighScore3",PlayerPrefs.GetInt("HighScore2"));
			//PlayerPrefs.SetInt("HighScore2",PlayerPrefs.GetInt("HighScore1"));
			PlayerPrefs.SetInt ("HighScore1", tempScore);
		//			takeScreenShot();
		}
		/*} else if (tempScore > PlayerPrefs.GetInt ("HighScore2")) {
			PlayerPrefs.SetInt("HighScore3",PlayerPrefs.GetInt("HighScore2"));
			PlayerPrefs.SetInt ("HighScore2", tempScore);

		} else if(tempScore>PlayerPrefs.GetInt("HighScore3")){
			PlayerPrefs.SetInt("HighScore3",tempScore);
		}*/
		PlayerPrefs.SetInt ("CurrentScore", tempScore); // This changes everytime because I want to display the user current score of the game when they died
	}
	
	void OnGUI()
	{
		if (health > MAX_HEALTH ) {
			health=MAX_HEALTH;
		}
		if (energyHealth > MAX_ENERGY) {
			energyHealth=MAX_ENERGY;
		}
		//health bar generation
		if (health > 0){
			GUI.DrawTexture (new Rect ((Screen.width-Screen.width+5), 15, 25, (Screen.height-20)), healthBarBackground);
			GUI.DrawTexture (new Rect ((Screen.width-Screen.width+5), 15, 25, MAX_HEALTH * (Screen.height-20)/20), healthTexture);
			GUI.DrawTexture (new Rect ((Screen.width-Screen.width+5), 15, 25, (Screen.height-Screen.height*health/20)), healthBarBackground);
		}	
		//enerygy bar generation
		if (energyHealth > 0) {
			GUI.DrawTexture(new Rect(Screen.width-30,15,25,(Screen.height-20)), healthBarBackground);

			GUI.DrawTexture(new Rect(Screen.width-30,15,25, MAX_HEALTH * (Screen.height-20)/20), energyTexture);
			GUI.DrawTexture(new Rect(Screen.width-30,15,25, (Screen.height-Screen.height*energyHealth/20)), healthBarBackground);
		}

	} // Generating in runtime
}
 