/*
 * This class is for generating enemies randomly to challenge the player
 * Enemies spawn rate is proportional to the player progression. 
 */
using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public Vector3 spawnValues;
	public int enemiesCount=15;
	private float spawnWait=2f;
	public float startWait=0f;
	public float enemiesWait=0f;
	public float spawnWhere= 4f;
	public float spawnWaitDec = 0.05f;
	private float minSpawnRate=0.4f;


	void Start (){
		StartCoroutine (SpwanEnemies ());
	}
	//spawns enemies
	IEnumerator SpwanEnemies ()
	{
		yield return new WaitForSeconds (startWait);
		while (true){
			for (int i = 0; i < enemiesCount; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWhere, spawnWhere),spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, transform.position+spawnPosition, spawnRotation);
			
				if(spawnWait<=minSpawnRate){
					spawnWait=minSpawnRate;
				}
				else{
					spawnWait-=spawnWaitDec;
				}
					yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (enemiesWait);
		}
	}
}
