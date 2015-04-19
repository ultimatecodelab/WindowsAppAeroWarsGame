/*
 * A class that keep track  of high score's
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour {

	public float time = 3f;
	public Texture backGroundText;

	void Update(){
		//windows phone back button 
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	//Entire HighScore is generated programmatically
	void OnGUI(){
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backGroundText); //loads background
		GUIStyle myStyle = new GUIStyle(GUI.skin.button);
		myStyle.alignment = TextAnchor.MiddleCenter;
		RectOffset margin = new RectOffset();
		margin.bottom = 10;
		margin.top = 10;
		myStyle.margin = margin;

		int ftSize = (int)(Screen.height * 0.08);
		myStyle.fontSize = ftSize;

		GUIStyle largeFont = new GUIStyle ();
		largeFont.fontSize = (int)(Screen.height*.15);
		largeFont.normal.textColor = Color.cyan;


		GUI.Label (new Rect(Screen.width * .05f, Screen.height * .25f, Screen.width * .5f, Screen.height * .1f),"Best: " + getHighScore1(),largeFont);

		if(GUI.Button (new Rect(Screen.width * .05f, Screen.height * .75f, Screen.width * .4f, Screen.height * .1f),"Main Menu",myStyle)){
			Application.LoadLevel(0);
		}
	}


	public static int getHighScore1()
	{
		return PlayerPrefs.GetInt("HighScore1");
	}
	public void postToFacebook(){
		//ShareToFacebook ("", "Aero Wars", "New Highscore : " + getHighScore1(), "",filePath, "http://www.facebook.com/");
		//Debug.Log (filePath);
	}
	/*public static int getHighScore2()
	{
		return PlayerPrefs.GetInt("HighScore2");
	}
	public static int getHighScore3()
	{
		return PlayerPrefs.GetInt("HighScore3");
	}*/
}
