using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour {

	public GameObject trap; 
	private float timer; 
	private bool triggered; 
	public GameObject arrow; 
	public float speed;
	public Transform target;
	public Transform startPoint; 
	private float startTime; 
	public float maxtime; 
	// Use this for initialization
	void Start () {
		trap.SetActive (false); 
		triggered = false; 
		timer = 0f; 
		arrow.transform.position = startPoint.position; 
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 
		//Debug.Log (timer);

		Move (); 
		if (arrow.transform.position == target.position)
						arrow.transform.position = startPoint.position; 
		

		if (triggered && timer < maxtime) {
			trap.SetActive (true); 	
		} else
			trap.SetActive (false);  
		
	}
	
	void OnTriggerEnter() {
		if (!triggered)
			timer = 0f; 
		triggered = true; 
		
		
	}

	void Move() {
		
		float step = speed * Time.deltaTime;
		
		arrow.transform.position = Vector3.MoveTowards (arrow.transform.position, target.position, step);  
		
	}
}
