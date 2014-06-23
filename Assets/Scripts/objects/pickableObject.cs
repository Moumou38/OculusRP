using UnityEngine;
using System.Collections;

public class pickableObject : MonoBehaviour {
	public bool treasure = false; 
	public Texture picture; 
 
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		//if(treasure && picture != null && !Tutorial.tuto) GUI.DrawTexture(new Rect(Screen.width - Screen.width * 0.2f, 0, Screen.width * 0.2f, Screen.height * 0.2f ), picture, ScaleMode.ScaleToFit, true, 0);
	
	}
}
