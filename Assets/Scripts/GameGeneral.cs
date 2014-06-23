using UnityEngine;
using System.Collections;

public class GameGeneral : MonoBehaviour {

	public path[] path; 
	public path intro; 
	public GameObject player; 
	public static path currentPath; 
	private bool rift ; 
	public Timer time; 
	private GameObject cam; 

	// Use this for initialization
	void Start () {
		rift = true; 

		if (OVRDevice.IsSensorPresent () && rift) {
						Debug.Log ("Oculus ready"); 
			cam = GameObject.Find("normalCam"); 
			cam.gameObject.SetActive(false); 

			Screen.lockCursor = true ;
			Screen.showCursor = false; 

				} 
		else {
			Debug.Log ("Fuck you !"); 
			cam = GameObject.Find("OVRCameraController"); 
			cam.gameObject.SetActive(false);  

			Screen.lockCursor = true ;
		
		}
						
		startTuto();

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (Screen.lockCursor + "  " +  Screen.showCursor); 
		/* //pause the game (UNUSED)
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(Constant.pause) { Constant.unPause(); time.Resume();    }
			else  {Constant.Pause (); time.Pause ();   }

				}
		if (Constant.pause) {
			Screen.lockCursor = false;
				}
		else Screen.lockCursor = true ; */

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

		time.SetTime (1000 * 60 * 60); 
		
		
	}
	
	void startTuto(){

		currentPath = GameObject.Instantiate (intro) as path; 

		Vector3 pos = currentPath.GetComponent<path> ().start.transform.position; 		
		pos.y += 3;
		player.transform.position = pos;

		time.SetTime (1000 * 60 *60); 



	}

	public void leavePath(){
		GameObject.DestroyImmediate(currentPath.gameObject);
		currentPath = null; 
		LoadPath(); 
	}

	public void EndGame() {
		Player.score = (int)((time.left ().Minutes + 1) * (time.left ().Seconds + 1) * (Player.health / 100)); 
		Application.LoadLevel ("gameover"); 
	}


}
