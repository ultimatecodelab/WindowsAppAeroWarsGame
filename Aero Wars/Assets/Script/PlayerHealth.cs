using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public float maxHorizontal = 4f;
	public float verticalSpeed = 1f;
	public float horizontalSpeed =2f;
	public AudioClip healthBoxCollection;

	public GameObject spark;

	void Update () {
		
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x + horizontalSpeed * Time.deltaTime,
		                                  -maxHorizontal, maxHorizontal),
		                                  transform.position.y,
		                                  transform.position.z + verticalSpeed * Time.deltaTime);
	}
	//If player hits the healthbox - his health and bullet will go up by certain percentage.
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
			collider.GetComponent<ShipController>().health+=5f;
			collider.GetComponent<ShipController>().energyHealth+=3f;
			AudioSource.PlayClipAtPoint(healthBoxCollection, transform.position);
			GameObject player = GameObject.Find("player");
			ShipController spController = player.GetComponent<ShipController>();
			spController.myParticle.emit=false;
			Destroy(gameObject);
		}
	}
	
}
