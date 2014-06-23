using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static int score;
	public static float maxHealth = 100; 
	public static float health = 100; 

	

	// Use this for initialization
	void Start () {
		score = 0; 
			
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0)
			Application.LoadLevel ("gameover"); 
	
	}

	void OnGUI() {

		/*
			GUI.DrawTexture(new Rect(Screen.width/2 - frameTexture.width/2 + frameTexture.width * 0.22f,frameTexture.height* 0.4f, frameTexture.width *0.75f, frameTexture.height* 0.45f), backgroundTexture, ScaleMode.ScaleAndCrop, true, 0 );
			
			
			//GUI.DrawTexture(new Rect(0,0, foregroundTexture.width * (health/maxHealth), foregroundTexture.height), foregroundTexture); //display a hand if we can carry object
			GUI.DrawTexture(new Rect(Screen.width/2 - frameTexture.width/2 + frameTexture.width * 0.22f,frameTexture.height* 0.4f,frameTexture.width *0.75f * (health/maxHealth) , frameTexture.height* 0.45f), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0 );
			
			GUI.DrawTexture(new Rect(Screen.width/2 - frameTexture.width/2,0, frameTexture.width, frameTexture.height), frameTexture, ScaleMode.ScaleToFit, true, 0 );

*/



	}
}
