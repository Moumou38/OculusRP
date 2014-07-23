using UnityEngine;
using System.Collections;

public class ExampleHUD : VRGUI 
{
	public GUISkin skin;
	private string[] menuOptions ; 
	public Timer time; 
	private pickableObject pick = null; 
	private Texture tex;

	public Texture backgroundTexture; 
	public Texture foregroundTexture; 	

	public Texture RP; 	
	private bool rift ; 

	public Texture[] timerTex; 

	public Texture[] heart; 
	private Texture[][] healthbar ; 

	public Texture menu; 
	public Texture[] button1; 
	private int b1; 
	private int b2; 
	public Texture[] button2; 

	public int x, y ;
	private int indexTimer; 
	private int selectedIndex = 1;

	private float timer; 

	private int currentheart; 
	private int index; 
	private int index1; 
	private int index2; 


	void Start() {
		menuOptions = new string[2];
		menuOptions[0] = "Escape";
		menuOptions[1] = "Continue";
		x = 0; 
		y = 0; 
		timer = 0f; 
		indexTimer = 0; 

		healthbar = new Texture[3][]; 
		healthbar [0] = heart; 
		healthbar [1] = heart; 
		healthbar [2] = heart; 
		currentheart = 0; 
		index = 0; 
		index1 = 0;
		index2 = 0;
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


	void health() {

		if (Obstacle.contact) {
						StartCoroutine ("ReduceLife"); 
						 

				}

	}

	IEnumerator ReduceLife() {
		int oldindex; 
		if (currentheart == 0) { 
						oldindex = index + 10;
			while(index < oldindex)  { 
				
				index++; 
				
				Debug.Log(index); 
				
				yield return null; }
				
			if (index >= 60 && currentheart  == 0) {
				index = 60; 
				currentheart++;
				
			}
		}

		if (currentheart == 1) { 
			oldindex = index1 + 10;
			while(index1 < oldindex)  { 
				
				index1++; 
				
				Debug.Log(index1); 
				
				yield return null; }
			
			if (index1 >= 60 && currentheart  == 1) {
				index1 = 60; 
				currentheart++;
				
			}
		}

		if (currentheart == 2) { 
			oldindex = index2 + 10;
			while(index2 < oldindex)  { 
				
				index2++; 
				
				Debug.Log(index2); 
				
				yield return null; }
			
			if (index2 >= 60 && currentheart  == 0) {
				index2 = 60; 
				currentheart++;
				
			}
		}
		  
	
	}



	void Update() {
		pick = GameObject.FindGameObjectWithTag("path").GetComponent<path>().treasure; 
		tex = pick.picture; 
		health (); 
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



	public override void OnVRGUI()
	{
		GUI.skin = skin;
		
	

		if ((OVRDevice.IsSensorPresent () && GameGeneral.rift)) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), RP);
			if (!Constant.pause) {
				GUI.DrawTexture (new Rect (Screen.width*0.7f - (Screen.width* 0.2f/2) , (Screen.width* 0.36f/4), Screen.width* 0.2f, Screen.height* 0.2f), timerTex[indexTimer]);
				skin.label.fontSize = (int)(Screen.width* 0.025f); 
				skin.label.fontStyle = FontStyle.Bold; 

				GUI.Label (new Rect (Screen.width*0.7f - (Screen.width* 0.035f) , (Screen.width* 0.36f/4)+(Screen.width* 0.036f), Screen.width* 0.2f, Screen.height* 0.2f), time.left ().Minutes + " : " + time.left ().Seconds); 
	
						/*if (pick != null && pick.treasure && pick.picture != null)
						GUI.DrawTexture (new Rect (Screen.width * 0.6f, Screen.height * 0.15f, Screen.width * 0.25f, Screen.height * 0.2f), tex, ScaleMode.StretchToFill, true, 0);
						*/
						
			}
			else {
				GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), menu, ScaleMode.StretchToFill, true, 0);

				GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button1 [b1], ScaleMode.StretchToFill, true, 0);
				GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button2 [b2], ScaleMode.StretchToFill, true, 0);


			}


			GUI.DrawTexture (new Rect (Screen.width * 0.5f, Screen.height * 0.2f, Screen.width * 0.10f, Screen.height * 0.10f), healthbar[0][index2], ScaleMode.ScaleToFit, true, 0);
			GUI.DrawTexture (new Rect (Screen.width * 0.5f + Screen.width * 0.037f  , Screen.height * 0.2f, Screen.width * 0.10f, Screen.height * 0.10f), healthbar[1][index1], ScaleMode.ScaleToFit, true, 0);
			GUI.DrawTexture (new Rect (Screen.width * 0.5f + Screen.width * 0.037f * 2f   , Screen.height * 0.2f, Screen.width * 0.10f, Screen.height * 0.10f), healthbar[2][index], ScaleMode.ScaleToFit, true, 0);
			} 

	}



}
