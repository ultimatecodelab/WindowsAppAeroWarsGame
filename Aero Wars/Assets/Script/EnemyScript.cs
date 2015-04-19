/*Everything that has to do with enemy
 * This class defines all the attributes/ states / and behaviour of an enemy
 * */

using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public GameObject bullet;
	public float maxHorizontal = 4f;
	private float verticalSpeed = -15f;
	public float horizontalSpeed =2f;
	public float horizontalSpeedChange = 2f;


	public float health = 1f;
	public float collisionDamage = 1f; //Number of bullet required to distroy an enemy
	private float verticleSpeedIncRate=-0.3f;
	public float killTime = 5f;

	private float MAX_VERTICLE_SPEED = -99f;//Max speed value
	public static int EXTRA_POINTS = 10;

	public ScoreBoard scoreBoard;

	public AudioClip enemyExplosionSound;
	public GameObject explosion;

	bool exploded;

	void Update () {
		killTime -= Time.deltaTime;
		if (killTime <= 0) {
			Destroy(gameObject); //destroying enemy by time. 5 seconds lifespan
		}

		verticalSpeed += verticleSpeedIncRate; //Speed of an enemy
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x + horizontalSpeed * Time.deltaTime,
		                    -maxHorizontal, maxHorizontal),
		                     transform.position.y,
		                     transform.position.z + verticalSpeed * Time.deltaTime);
		if (health <= 0) {
			Destroy(gameObject); //enemy health can be increased, by default 1 bullet is enough to destroy it
		}
	
		if(verticalSpeed<=MAX_VERTICLE_SPEED){
			verticalSpeed=MAX_VERTICLE_SPEED;
		} //tracking maxspeed
		Debug.Log (verticalSpeed);
		
	}
	
	//For every enemy killed -> player gets the bonus of 10 points
	static void IncreamentPlayerScoreBonus (){
		GameObject playerSc = GameObject.Find ("ScoreTxt");
		PlayerScore score2 = playerSc.GetComponent<PlayerScore> ();
		score2.bonusScore (EXTRA_POINTS);
	}
	IEnumerator explodeEnemy() {

		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(audio.clip.length);

		Debug.Log("After Waiting 2 Seconds");
	}
	void Start () {
		if(gameObject.particleSystem)
		{
			GameObject.Destroy(gameObject, gameObject.particleSystem.duration + gameObject.particleSystem.startLifetime);
		}
	}
	
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "PlayerBullet") {
			health-=collider.GetComponent<PlayerBullet>().damage;
			IncreamentPlayerScoreBonus (); 
			//explosion when bullet touches the enemy
			Instantiate(explosion, transform.position + new Vector3 (0f, 0f, 1.2f), transform.rotation);
			AudioSource.PlayClipAtPoint(enemyExplosionSound, transform.position);
			Destroy(collider.gameObject);// destroying bullet 
		
		
		}
		if (collider.tag == "Player") {
			collider.GetComponent<ShipController>().health-=collisionDamage;
			Instantiate (explosion, transform.position + new Vector3 (0f, 0f, 1.2f), transform.rotation);
			AudioSource.PlayClipAtPoint(enemyExplosionSound, transform.position);
			Destroy(gameObject); //destroying enemy after getting hit by an enemy

		}
	}



}
