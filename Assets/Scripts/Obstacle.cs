using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "obstacle") {
			this.transform.position -= this.transform.forward; 
			Debug.Log ("CONTAAAAAACT"); 
			Player.health -= 12; 
		}


		
	}
}
