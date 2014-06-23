using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUIStyle custom;  
	// Array of menu item control names.
	private string[] menuOptions ; 

	
	// Default selected menu item (in this case, Tutorial).
	private int selectedIndex = 0;

	void Start () {
		menuOptions = new string[2];
		menuOptions[0] = "Play";
		menuOptions[1] = "Explications";
		//menuOptions[3] = "Exit";
		Vector2 v = new Vector2 (Screen.width/2 - 150, Screen.height / 4); 
		custom.contentOffset = v; 
	}
	
	// void to scroll through possible menu items array, looping back to start/end depending on direction of movement.
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
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			selectedIndex = menuSelection(menuOptions, selectedIndex, "down");
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			selectedIndex = menuSelection(menuOptions, selectedIndex, "up");
		}
	}
	
	void OnGUI ()
	{
		GUILayout.Button ("Oculus RP", custom, GUILayout.Width(300));

		GUI.SetNextControlName ("Play");
		if(GUILayout.Button ("Jouer",  custom , GUILayout.Width(300))) {
			//Do game stuff.
			Debug.Log("PLAY");
			Application.LoadLevel("game"); 
		}
		
		GUI.SetNextControlName ("Explications");
		if(GUILayout.Button ("retinopathie pigmentaire", custom, GUILayout.Width(300))) {
			//Do high score stuff.
		}
		
		/* GUI.SetNextControlName ("Exit");
		if(GUILayout.Button ("retinopathie pigmentaire", custom)) {
			//Do quit stuff.
		} */
		
		GUI.FocusControl (menuOptions[selectedIndex]);
	}







	/*public GUIStyle custom;  
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		// Provide the name of the Style as the final argument to use it
		if(GUILayout.Button ("retinopathie pigmentaire", custom)) Debug.Log("caca");
		if(GUILayout.Button ("Jouer", custom)) Debug.Log("caca");
		// If you do not want to apply the Style, do not provide the name
		//GUILayout.Button ("I am a normal UnityGUI Button without custom style");
	} */
}
