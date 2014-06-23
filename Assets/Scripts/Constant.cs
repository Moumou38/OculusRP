using UnityEngine;
using System.Collections;

public class Constant : MonoBehaviour {

	public static float sensitivity = 2.0f;
	public static bool invertCamera = false;
	public static int difficulty = 1 ; // 1 = hard, 3 = easy
	public static bool pause = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void Pause() {
		pause = true; 
		Time.timeScale = 0; 
	}

	public static void unPause() {
		pause = false;
		Time.timeScale = 1; 
	}


}
