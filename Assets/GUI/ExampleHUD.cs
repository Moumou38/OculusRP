using UnityEngine;
using System.Collections;

public class ExampleHUD : VRGUI 
{
	public GUISkin skin;
	public Timer time; 
	private pickableObject pick = null; 
	private Texture tex;
	public Texture backgroundTexture; 
	public Texture frameTexture;
	public Texture foregroundTexture; 	
	public Texture RP; 	
	private bool rift ; 


	void Update() {
		pick = GameObject.FindGameObjectWithTag("path").GetComponent<path>().treasure; 
		tex = pick.picture; 
	}

	public override void OnVRGUI()
	{
		GUI.skin = skin;
		
		GUI.skin.label.fontSize = 50; 

		if (GameGeneral.rift) {
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), RP);
						GUI.Label (new Rect (Screen.width * 0.25f, Screen.height * 0.2f, 800, 100), time.left ().Minutes + " : " + time.left ().Seconds); 
	
						if (pick != null && pick.treasure && pick.picture != null)
						GUI.DrawTexture (new Rect (Screen.width * 0.6f, Screen.height * 0.15f, Screen.width * 0.25f, Screen.height * 0.2f), tex, ScaleMode.ScaleToFit, true, 0);
	
						GUI.DrawTexture (new Rect (Screen.width / 2 - frameTexture.width / 2 + frameTexture.width * 0.22f, Screen.height * 0.15f + frameTexture.height * 0.4f, frameTexture.width * 0.75f, frameTexture.height * 0.45f), backgroundTexture, ScaleMode.ScaleAndCrop, true, 0);
		
						//GUI.DrawTexture(new Rect(0,0, foregroundTexture.width * (health/maxHealth), foregroundTexture.height), foregroundTexture); //display a hand if we can carry object
						GUI.DrawTexture (new Rect (Screen.width / 2 - frameTexture.width / 2 + frameTexture.width * 0.22f, Screen.height * 0.15f + frameTexture.height * 0.4f, frameTexture.width * 0.75f * (Player.health / Player.maxHealth), frameTexture.height * 0.45f), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);
		
						GUI.DrawTexture (new Rect (Screen.width / 2 - frameTexture.width / 2, Screen.height * 0.15f, frameTexture.width, frameTexture.height), frameTexture, ScaleMode.ScaleToFit, true, 0);
				} 

		else {

			GUI.DrawTexture (new Rect (0, Screen.height*0.1f, Screen.width, Screen.height*0.8f), RP);


				
		
		
		}
	}
}
