using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {
	
	public float scoreF = 0f;
	public GUIText scoreTxt2;
	public int score;

	// Update is called once per frame
	void Update () {
		scoreF+=   Time.deltaTime;
		score= (int)scoreF;
		DisplayText ();
	}
	
	
	public void DisplayText(){
		scoreTxt2.text = "Score: " + score;
	}
	//This method is called when player hits/ collect the health box
	public void bonusScore(int extraScore){
		scoreF += extraScore;

	}
}
