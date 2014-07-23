using UnityEngine;
using System.Collections;

public class MenuGameOver : MonoBehaviour {

	public GUIStyle custom;  

	public GUISkin skin;


	// Array of menu item control names.
	private string[] menuOptions ; 
	public Texture picture; 
	public Texture hand; 
	public Texture dark; 
	public Texture buttonRP; 
	public Texture[] menu; 
	public Texture[] level; 
	public Texture[] button1; 
	private int b1; 
	private int b2; 
	public Texture[] button2; 
	private int state; // 0 = menu pricipal ; 1 = RP

	public int x, y ;

	private float timer ; 
	private bool intro ; 
	
	// Default selected menu item (in this case, Tutorial).
	private int selectedIndex = 0;

	void Start () {
		timer = 0f; 
		state = 0; 
		b1 = 1; 
		b2 = 0; 
		x = 0; y = 0; 
		Constant.unPause();
		menuOptions = new string[2];
		menuOptions[0] = "Explications";
		menuOptions[1] = "Retour";
		Vector2 v = new Vector2 (Screen.width/2 - 150, Screen.height / 4); 
		custom.contentOffset = v; 

		Screen.showCursor = false; 
		Screen.lockCursor = true ;

		if ((Player.score + Player.time + Player.health) <= 55)
						menu [0] = level [0]; //noob
		else if ((Player.score + Player.time + Player.health) < 150 && (Player.score + Player.time + Player.health) > 55)
			menu [0] = level [1]; //mid
		else
			menu [0] = level [2]; //expert



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

	void changePage(){
	
		if (state == 0)
				state = 1;
		else
				state = 0; 
			
	
	}

	IEnumerator SlideOut() {
		for(int i=0; i< Screen.height; i+=(int) (Screen.height * 0.03f))  { 
			y=i; 
			//x=-i; 

			yield return null; }
		changePage (); 
		StartCoroutine("SlideIn");
		}

	IEnumerator SlideIn() {
	
		for(int i=Screen.height; i>0; i-= (int) (Screen.height * 0.03f) )  { 
			y=i; 
			yield return null; }
	}

	void Update ()
	{

						if (Input.GetAxisRaw ("Vertical") > 0) {
								selectedIndex = menuSelection (menuOptions, selectedIndex, "down");

						}
		
						if (Input.GetAxisRaw ("Vertical") < 0) {
								selectedIndex = menuSelection (menuOptions, selectedIndex, "up");

						}
						if (Input.GetButtonDown ("Jump")) {
								if (state == 0) {
										if (selectedIndex == 1)
											Application.LoadLevelAsync ("Menu");
										else {
												StartCoroutine ("SlideOut");
										}
								} else {
										StartCoroutine ("SlideOut");
								}
						}

						if (selectedIndex == 0) {
								b1 = 1;
								b2 = 0; 
						} else {
								b1 = 0;
								b2 = 1; 
						}
				
			
		}

	
	void OnGUI ()
	{

		GUI.skin = skin; 

				
						//GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), dark, ScaleMode.StretchToFill, true, 0);

						GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), menu [state], ScaleMode.StretchToFill, true, 0);
						GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), hand, ScaleMode.StretchToFill, true, 0);



						if (!intro) { 
								if (state == 0) {
										GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button1 [b1], ScaleMode.StretchToFill, true, 0);
										GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button2 [b2], ScaleMode.StretchToFill, true, 0);
										skin.label.fontSize = (int)(Screen.width * 0.032f); 
										GUI.Label (new Rect (Screen.width * 0.42f +x, Screen.height * 0.51f +y, Screen.height * 0.2f, Screen.height * 0.2f), ""+Player.health+"");
										GUI.Label (new Rect (Screen.width * 0.42f +x, Screen.height * 0.56f +y, Screen.height * 0.2f, Screen.height * 0.2f), ""+Player.time+"");
										skin.label.fontSize = (int)(Screen.width * 0.047f); 
										GUI.Label (new Rect (Screen.width * 0.42f +x, Screen.height * 0.62f +y, Screen.height * 0.2f, Screen.height * 0.2f), ""+ (Player.score + Player.time+ Player.health) +""); 
				
								} else {
										GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), buttonRP, ScaleMode.StretchToFill, true, 0);
								}
						}

			

	
	}

}
