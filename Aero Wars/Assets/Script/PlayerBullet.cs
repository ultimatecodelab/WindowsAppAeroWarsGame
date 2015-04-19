/*Script that defines the bullet states and its properties
 * */
using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	public float speed = 9f;
	public float accel = 0f;
	public float destroyAfter = 3f;
	public float damage=1f;
	// Update is called once per frame
	void Update () {
		speed += accel * Time.deltaTime;
		destroyAfter -= Time.deltaTime;
		if (destroyAfter <= 0) {
			Destroy(gameObject);
		}
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
	}
}
