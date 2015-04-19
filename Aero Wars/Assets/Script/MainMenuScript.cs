using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Texture backGroundText;
	public Texture titleText;
	public Texture titleText2;

	int isMuted=0;
	public  string text = "MUTE SOUND";
	
	void Awake(){
		if (PlayerPrefs.GetInt ("isMuted") == 1) {
		text = "UNMUTE";
		AudioListener.pause = true;
		audio.mute = true;
		Debug.Log (PlayerPrefs.GetInt ("isMuted"));
	  } 

	}
	void Update(){
		//back button : quits app
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}


	//Generating menus
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backGroundText);

		//GUI.DrawTexture (new Rect (Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.height * .2f), titleText);
		GUIStyle myStyle = new GUIStyle(GUI.skin.button);
		myStyle.alignment = TextAnchor.MiddleCenter;
		RectOffset margin = new RectOffset();
		margin.bottom = 10;
		margin.top = 10;
		myStyle.margin = margin;

		int ftSize = (int)(Screen.height * .07);
		myStyle.fontSize = ftSize;


		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height * .30f, Screen.width * .5f, Screen.height * .1f),"NEW GAME",myStyle))
		{
			//Do SomeThing..
			Application.LoadLevel(1);
		}
		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height * .42f, Screen.width * .5f, Screen.height * .1f),"SCORES",myStyle))
		{
			//Do SomeThing..
			Application.LoadLevel(3);
		}


		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .54f, Screen.width * .5f, Screen.height * .1f), text, myStyle)) {

			if (audio.mute) {
					audio.mute = false;
					AudioListener.pause = false;
					isMuted = 0;
					text = "MUTE SOUND";
					PlayerPrefs.SetInt ("isMuted", isMuted);
			} else {
					audio.mute = true;
					AudioListener.pause = true;
					isMuted = 1;
					text = "UNMUTE";
					PlayerPrefs.SetInt ("isMuted", isMuted);
			}

		}
		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height * .66f, Screen.width * .5f, Screen.height * .1f),"HOW TO PLAY",myStyle)){
			//TODO
			Application.LoadLevel(4);
		}
		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height * .78f, Screen.width * .5f, Screen.height * .1f),"QUIT",myStyle)){
			Application.Quit();

		}

		//future update for different Modes
		/*GUI.Label(new Rect(Screen.width * .20f, Screen.height * .90f, Screen.width * .5f, Screen.height * .1f),"Select Mode: ");

		if(GUI.Toggle (new Rect(Screen.width * .40f, Screen.height * .90f, Screen.width * .5f, Screen.height * .1f),false,"Classic")){
			//TODO
			
		}
		if(GUI.Toggle (new Rect(Screen.width * .60f, Screen.height * .90f, Screen.width * .5f, Screen.height * .1f),false,"Defense")){
			//TODO

			
		}
		if(GUI.Toggle (new Rect(Screen.width * .80f, Screen.height * .90f, Screen.width * .5f, Screen.height * .1f),false,"Survival")){
			//TODO
			
		}*/

	}
}
