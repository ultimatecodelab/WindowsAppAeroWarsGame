using UnityEngine;
using System.Collections;

public class SpawnHealthBox : MonoBehaviour {
	
	public GameObject enemy;
	public Vector3 spawnValues;
	public int healthBoxCount=0;
	//public float spawnWait=2f;
	public float startWait=0f;
	public float waveWait=0f;
	public float spawnWhere= 4f;
	
	void Start (){
		StartCoroutine (SpawnHealth ());
	}
	
	public AudioClip healthBoxCollection;
	
	IEnumerator SpawnHealth (){
		yield return new WaitForSeconds (30);
		while (true) {
				for (int i = 0; i < healthBoxCount; i++) {
						//yield return new WaitForSeconds (Random.Range(30,50));
						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWhere, spawnWhere), spawnValues.y, spawnValues.z);
						Quaternion spawnRotation = Quaternion.identity;

						Instantiate (enemy, transform.position + spawnPosition, spawnRotation);

						yield return new WaitForSeconds (Random.Range (30, 40));
				}
				yield return new WaitForSeconds (waveWait);
		}
	}
		
		


}
