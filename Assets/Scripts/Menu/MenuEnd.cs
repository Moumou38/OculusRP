using UnityEngine;
using System.Collections;

public class MenuEnd : MonoBehaviour {

	public GUIStyle custom;  
	// Array of menu item control names.
	private string[] menuOptions ; 
	
	
	// Default selected menu item (in this case, Tutorial).
	private int selectedIndex = 0;
	
	void Start () {
		menuOptions = new string[3];
		menuOptions[0] = "Play";
		menuOptions[1] = "Explications";
		menuOptions[2] = "Accueil";
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
		GUILayout.Button ("Score : " + Player.score , custom, GUILayout.Width(300));
		
		GUI.SetNextControlName ("Play");
		if(GUILayout.Button ("Rejouer",  custom , GUILayout.Width(300))) {
			//Do game stuff.
			Debug.Log("PLAY");
			Application.LoadLevel("game"); 
		}
		
		GUI.SetNextControlName ("Explications");
		if(GUILayout.Button ("retinopathie pigmentaire", custom, GUILayout.Width(300))) {
			//Do high score stuff.
		}

		GUI.SetNextControlName ("Accueil");
		if(GUILayout.Button ("Retour au menu principal", custom, GUILayout.Width(300))) {
			Application.LoadLevel("menu"); 
			//Do high score stuff.
		}
		
		/* GUI.SetNextControlName ("Exit");
		if(GUILayout.Button ("retinopathie pigmentaire", custom)) {
			//Do quit stuff.
		} */
		
		GUI.FocusControl (menuOptions[selectedIndex]);
	}
	

}
