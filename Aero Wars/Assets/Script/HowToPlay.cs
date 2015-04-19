using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour {
	public Texture backGroundText;
	
	void OnGUI() {

		GUIStyle myStyle = new GUIStyle(GUI.skin.button);
		myStyle.alignment = TextAnchor.MiddleCenter;
		RectOffset margin = new RectOffset();
		margin.bottom = 10;
		margin.top = 10;
		myStyle.margin = margin;
		
		int ftSize = (int)(Screen.height * 0.07);
		myStyle.fontSize = ftSize;
		GUIStyle largeFont = new GUIStyle ();
		largeFont.fontSize = (int)(Screen.height*0.06);

		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backGroundText);

		GUI.Label (new Rect(Screen.width * .03f, Screen.height * .25f, Screen.width * .5f, Screen.height * .1f),"**Keyboard: Use Arrow Keys To Move\n  and Spacebar to Shoot",largeFont);
		GUI.Label (new Rect(Screen.width * .03f, Screen.height * .40f, Screen.width * .5f, Screen.height * .1f),"**Mobile/Tablet: Tilt To Move & Tap To Shoot ",largeFont);
		GUI.Label (new Rect(Screen.width * .03f, Screen.height * .50f, Screen.width * .5f, Screen.height * .1f),"**Left Bar: Shows Health / Right Bar: Shows Ammo",largeFont);
		GUI.Label (new Rect(Screen.width * .03f, Screen.height * .60f, Screen.width * .5f, Screen.height * .1f),"**Collect power-ups(blue sphere) to get extra \n  health & ammo pack",largeFont);
		//GUI.Label (new Rect(Screen.width * .03f, Screen.height * .85f, Screen.width * .5f, Screen.height * .1f),"Good Luck!",largeFont);


		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height * .80f, Screen.width * .3f, Screen.height * .1f),"MAIN MENU",myStyle)){
			Application.LoadLevel(0);
		}
	}

}
