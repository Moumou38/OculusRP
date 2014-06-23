using UnityEngine;
using System.Collections;

public class controlCam : MonoBehaviour {
	private CharacterController controller; 
	private GameObject mainCam; 
	// Use this for initialization
	void Start () {
		mainCam = GameObject.Find ("Main Camera"); 
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 tmpVec;
		tmpVec = controller.transform.forward;
		tmpVec.y = 0;
		tmpVec.Normalize();
		controller.Move(tmpVec); */



		if (Input.GetKey (KeyCode.Z))
			this.transform.position += mainCam.transform.forward*0.1f; 
		if (Input.GetKey (KeyCode.S))
			this.transform.position -= mainCam.transform.forward*0.1f; 
		if (Input.GetKey (KeyCode.D))
			this.transform.position += mainCam.transform.right*0.1f; 
		if (Input.GetKey (KeyCode.Q))
			this.transform.position -= mainCam.transform.right*0.1f; 


			
	}
}
