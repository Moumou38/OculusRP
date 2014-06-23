using UnityEngine;
using System.Collections;

public class RP : MonoBehaviour {

	public Texture[] rpTab; 
	// Use this for initialization
	void Start () {
		int x, y, w, h; 

		x = - Screen.width / 2; 
		y = - Screen.height / 2; 
		w = Screen.width; 
		h = Screen.height; 

		Rect tmp = new Rect (x, y, w, h); 

		this.GetComponent<GUITexture> ().pixelInset = tmp; 
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Constant.difficulty == 1)
			this.GetComponent<GUITexture>().texture = rpTab [0]; 
		if (Constant.difficulty == 2)
			this.GetComponent<GUITexture>().texture = rpTab [1]; 
		if (Constant.difficulty == 3)
			this.GetComponent<GUITexture>().texture = rpTab [2]; 
		if (Constant.difficulty == 0) 
			this.GetComponent<GUITexture> ().texture = null; 

		if (Input.GetKey (KeyCode.F1))
			Constant.difficulty = 1; 
		if (Input.GetKey (KeyCode.F2))
			Constant.difficulty = 2; 
		if (Input.GetKey (KeyCode.F3))
			Constant.difficulty = 3; 
		if (Input.GetKey (KeyCode.F4)) { 
			this.GetComponent<GUITexture> ().texture = null; 
			Constant.difficulty = 0; 

				}
		//Debug.Log (Constant.difficulty); 


	}


}
