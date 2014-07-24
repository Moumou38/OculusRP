using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public static bool contact; 
	public bool cooldown; 
	private float timer ; 

	// Use this for initialization
	void Start () {
		contact = false; 
		timer = 0; 
		cooldown = false; 
	}
	
	// Update is called once per frame
	void Update () {

		if (contact) {
			timer = 0f; 
			Player.health -= 10; 
			Debug.Log(Player.health); 		
			
				}

		//Debug.Log (contact); 
		contact = false; 
		timer += Time.deltaTime; 

	
	}

	void  OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "obstacle") {
			if(timer > 2f) { this.transform.position -= this.transform.forward * 0.3f; 
			//Debug.Log ("CONTAAAAAACT"); 
			 
				contact = true; }
		}
		//else contact = false; 


		
	}
}
