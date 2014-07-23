using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public static bool contact; 

	// Use this for initialization
	void Start () {
		contact = false; 
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (contact); 
		contact = false; 
	
	}

	void  OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "obstacle") {
			this.transform.position -= this.transform.forward; 
			Debug.Log ("CONTAAAAAACT"); 
			Player.health -= 10; 
			contact = true; 
		}
		//else contact = false; 


		
	}
}
