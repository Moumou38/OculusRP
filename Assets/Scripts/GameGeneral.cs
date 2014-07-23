using UnityEngine;
using System.Collections;

public class GameGeneral : MonoBehaviour {

	public path[] path; 
	public path intro; 
	public GameObject player; 
	public static path currentPath; 
	public static bool rift ; 
	public Timer time; 
	private GameObject cam; 

	// Use this for initialization
	void Start () {
		rift = true; 

		if (OVRDevice.IsSensorPresent () && rift) {
			//Debug.Log ("Oculus ready"); 
			cam = GameObject.Find("normalCam"); 
			cam.gameObject.SetActive(false); 


			Screen.lockCursor = true ;
			Screen.showCursor = false; 

				} 
		else {
			//Debug.Log ("Fuck you !"); 
			cam = GameObject.Find("OVRCameraController"); 
			cam.gameObject.SetActive(false);  
			//Screen.showCursor = false; 
			Screen.lockCursor = true ;
			rift = false; 
		
		}
						
		startTuto();

	}
	
	// Update is called once per frame
	void Update () {

		//Screen.lockCursor = true ;
		//Screen.showCursor = false; 

		//Debug.Log (Screen.lockCursor + "  " +  Screen.showCursor); 
		 //pause the game (UNUSED)
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(Constant.pause) { Constant.unPause(); time.Resume(); if (OVRDevice.IsSensorPresent () && rift) GameObject.Find("OVRCameraController").GetComponent<OVRCameraController>().EnableOrientation = true;   }
			else  {Constant.Pause (); time.Pause (); if (OVRDevice.IsSensorPresent () && rift) GameObject.Find("OVRCameraController").GetComponent<OVRCameraController>().EnableOrientation = false;   }

				}


		if (time.end)
			Application.LoadLevel ("gameover"); 

		//Debug.Log (time.left ()); 


	
	}

	void LoadPath(){
		int re = Random.Range(0, path.Length);
		currentPath = GameObject.Instantiate(path[re]) as path;

		Vector3 pos = currentPath.GetComponent<path> ().start.transform.position; 		
		pos.y += 3;
		player.transform.position = pos;

		time.SetTime (1000 * 2 * 60); 
		
		
	}
	
	void startTuto(){

		currentPath = GameObject.Instantiate (intro) as path; 

		Vector3 pos = currentPath.GetComponent<path> ().start.transform.position; 		
		pos.y += 3;
		player.transform.position = pos;

		time.SetTime (1000 * 2 *60); 



	}

	public void leavePath(){
		GameObject.DestroyImmediate(currentPath.gameObject);
		currentPath = null; 
		LoadPath(); 
	}

	public void EndGame() {
		Player.time = (time.left ().Minutes + 1) * (time.left ().Seconds) ; 
		Player.score = (int)((time.left ().Minutes + 1) * (time.left ().Seconds + 1) * (Player.health / 100)); 
		Application.LoadLevel ("gameover"); 
	}


}
