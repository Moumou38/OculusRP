using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUIStyle custom;  
	// Array of menu item control names.
	private string[] menuOptions ; 
	public Texture introTex; 
	public Texture picture; 
	public Texture hand; 
	public Texture buttonRP; 
	public Texture[] menu; 
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
		intro = true; 
		state = 0; 
		b1 = 1; 
		b2 = 0; 
		x = 0; y = 0; 
		Constant.unPause();
		menuOptions = new string[2];
		menuOptions[0] = "Play";
		menuOptions[1] = "Explications";
		Vector2 v = new Vector2 (Screen.width/2 - 150, Screen.height / 4); 
		custom.contentOffset = v; 

		Screen.showCursor = false; 
		Screen.lockCursor = true ;
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
		if (!intro) { 
						if (state == 0)
								state = 1;
						else
								state = 0; 
				} 
		else {
			intro = false; 	
		
		}
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
		if (!intro) {
						if (Input.GetAxisRaw ("Vertical") > 0) {
								selectedIndex = menuSelection (menuOptions, selectedIndex, "down");

						}
		
						if (Input.GetAxisRaw ("Vertical") < 0) {
								selectedIndex = menuSelection (menuOptions, selectedIndex, "up");

						}
						if (Input.GetButtonDown ("Jump")) {
								if (state == 0) {
										if (selectedIndex == 0)
						Application.LoadLevelAsync ("game");
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
				} else {
			timer += Time.deltaTime; 
			if(timer > 3f && timer < 4f) StartCoroutine ("SlideIn");
			if(timer > 6.5f) StartCoroutine ("SlideOut");
			
		}
	}
	
	void OnGUI ()
	{

		if (!(timer < 3f )) {

						if (intro)
								GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), introTex, ScaleMode.StretchToFill, true, 0);
						else
								GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), menu [state], ScaleMode.StretchToFill, true, 0);
						//GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), hand, ScaleMode.StretchToFill, true, 0);

						if (!intro) { 
								if (state == 0) {
										GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button1 [b1], ScaleMode.StretchToFill, true, 0);
										GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), button2 [b2], ScaleMode.StretchToFill, true, 0);
				
								} else {
										GUI.DrawTexture (new Rect (x, y, Screen.width, Screen.height), buttonRP, ScaleMode.StretchToFill, true, 0);
								}
						}

				}

	
	}

}
