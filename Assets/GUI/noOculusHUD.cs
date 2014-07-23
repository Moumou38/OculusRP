using UnityEngine;
using System.Collections;

public class noOculusHUD : MonoBehaviour {
	public GUISkin skin;
	private string[] menuOptions ; 
	public Timer time; 
	private pickableObject pick = null; 
	private Texture tex;
	public Texture backgroundTexture; 
	public Texture frameTexture;
	public Texture foregroundTexture; 	
	public Texture RP; 	
	private bool rift ; 
	
	public Texture[] timerTex; 
	
	public Texture menu; 
	public Texture[] button1; 
	private int b1; 
	private int b2; 
	public Texture[] button2; 
	
	public int x, y ;
	private int indexTimer; 
	private int selectedIndex = 1;
	
	private float timer; 
	
	
	void Start() {
		menuOptions = new string[2];
		menuOptions[0] = "Escape";
		menuOptions[1] = "Continue";
		x = 0; 
		y = 0; 
		timer = 0f; 
		indexTimer = 0; 
	}
	
	int menuSelection (string[] menuItems,int selectedItem,string direction) {
		if (direction == "up") {
			
			if (selectedItem == 0) {
				selectedItem = menuItems.Length - 1;
			} else {
				selectedItem -= 1;
			}
		}
		
		if (direction == "down") {
			if (selectedItem == menuItems.Length - 1) {
				selectedItem = 0;
			} else {
				selectedItem += 1;
			}
		}
		
		return selectedItem;
	}
	
	
	
	void Update() {
		pick = GameObject.FindGameObjectWithTag("path").GetComponent<path>().treasure; 
		tex = pick.picture; 
		
		if (Constant.pause) {
			
			if (Input.GetAxisRaw ("Vertical") > 0) {
				selectedIndex = menuSelection (menuOptions, selectedIndex, "down");
				
			}
			
			if (Input.GetAxisRaw ("Vertical") < 0) {
				selectedIndex = menuSelection (menuOptions, selectedIndex, "up");
				
			}
			
			if (selectedIndex == 0) {
				b1 = 1;
				b2 = 0; 
			} else {
				b1 = 0;
				b2 = 1; 
			}
			
			if (Input.GetButtonDown ("Jump")) {
				
				if (selectedIndex == 0) {
					Constant.unPause ();
					time.Resume ();
					Application.LoadLevel ("menu");
				} else {
					Constant.pause = false; 	
					Constant.unPause ();
					time.Resume ();
					
				}
			}
			
		} else {
			if(timer > 2f) {
				if(indexTimer < 61) indexTimer++;
				timer = 0; }
			
		}
		timer += Time.deltaTime; 
		
	}
	
	
	
	void OnGUI() {
		
		if (!(OVRDevice.IsSensorPresent () && GameGeneral.rift)) {
			
			GUI.skin = skin;
			
			
			
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), RP);
			if (!Constant.pause) {
				GUI.DrawTexture (new Rect (Screen.width / 2 - (Screen.width * 0.15f / 2), (Screen.width * 0.15f / 4), Screen.height * 0.15f, Screen.height * 0.15f), timerTex [indexTimer]);
				skin.label.fontSize = (int)(Screen.width * 0.015f); 
				skin.label.fontStyle = FontStyle.Bold; 
				GUI.Label (new Rect (Screen.width / 2 - (Screen.width * 0.052f), (Screen.width * 0.15f / 4) + (Screen.width * 0.03f), Screen.height * 0.2f, Screen.height * 0.2f), time.left ().Minutes + " : " + time.left ().Seconds); 
				
				if (pick != null && pick.treasure && pick.picture != null)
					GUI.DrawTexture (new Rect (Screen.width * 0.6f, Screen.height * 0.15f, Screen.height * 0.25f, Screen.height * 0.2f), tex, ScaleMode.StretchToFill, true, 0);

				
			} else {
				GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), menu, ScaleMode.StretchToFill, true, 0);					
				GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button1 [b1], ScaleMode.StretchToFill, true, 0);
				GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button2 [b2], ScaleMode.StretchToFill, true, 0);


				
				
			}
			
		} 
		
		
		
	}
}
