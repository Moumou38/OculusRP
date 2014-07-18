using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {
	private bool open; 
	private int state; 

	// Use this for initialization
	void Start () {
		animation ["open"].speed = 1.0f;
		animation.Play ("open");
		open = false; 
		state = 0; 
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && state == 0) {
						animation ["page1"].speed = 1.0f;
						animation.Play ("page1");
			state = 1; 
				}
		if (Input.GetKeyDown (KeyCode.R)) {
			animation ["open"].speed = -1.0f;
			animation["open"].time = animation["open"].length;
			animation.Play ("open");
		}
	
	}
}
