using UnityEngine;
using System.Collections;

public class FlameTrap : MonoBehaviour {
	private GameObject trap; 
	private float timer; 
	private bool triggered; 
	// Use this for initialization
	void Start () {
		trap = GameObject.Find("flametrap/trap"); 
		trap.SetActive (false); 
		triggered = false; 
		timer = 0f; 
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 
		//Debug.Log (timer);

		if (triggered && timer < 8f) {
						trap.SetActive (true); 	
				} else
						trap.SetActive (false); 
	
	}

	void OnTriggerEnter() {
		if (!triggered)
			timer = 0f; 
		triggered = true; 


	}
}
