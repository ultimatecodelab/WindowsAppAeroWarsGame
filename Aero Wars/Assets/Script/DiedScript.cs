/*Aero Wars  - DiedScript
 * This script is to display the gave over scene. All the visual elements
 * are generated in the runtime
 * */
using UnityEngine;
using System.Collections;
public class DiedScript : MonoBehaviour {
	public float time = 3f;
	public Texture diedScreenText;

	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	//This scene is loaded for 3 seconds before loading the main menu scene
	void Update () {
		time -= Time.deltaTime; //keeping track of time
		if (time <= 0) 
		{
			Application.LoadLevel(0);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	} // End of Update

	//This method is generating all the visual elements programmatically
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),diedScreenText);	
		GUIStyle largeFont = new GUIStyle ();
		largeFont.fontSize=(int)(Screen.height * 0.2);
		largeFont.normal.textColor = Color.cyan;
		
		GUI.Label (new Rect(Screen.width * .10f, Screen.height * .30f, Screen.width * .5f, Screen.height * .1f),"Game Over ",largeFont);
		GUI.Label (new Rect(Screen.width * .10f, Screen.height * .60f, Screen.width * .5f, Screen.height * .1f),"Score: " +getCurrentScore(),largeFont);
	}
	//Gets a last gameplay score
	public static int getCurrentScore()
	{
		return PlayerPrefs.GetInt ("CurrentScore");
	}
}
