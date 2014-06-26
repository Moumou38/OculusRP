using UnityEngine;
using System.Collections;

public class movingStone : MonoBehaviour {
	public bool moved  ; 
	private bool collided ; 
	private bool active ; 
	public float speed;
	public Transform target;
	public Transform startPoint; 
	private float startTime; 
	// Use this for initialization
	void Start () {
		moved = false; 
		collided = false; 
		active = false; 
		startPoint = transform;


	}
	
	// Update is called once per frame
	void Update () {
		startTime = Time.time; 


		if(collided && !moved) {
			if( Input.GetKeyDown(KeyCode.E))
			{
				active = true; 
				collided = false; 
			}
		}

		if(active && !moved) Move (); 


	}

	void OnTriggerEnter(){
		if (!moved)
		{
			collided = true;

		}
	}
	void OnTriggerExit() {
		collided = false; 
	}

	void Move() {

		float step = speed * Time.deltaTime;

		this.transform.position = Vector3.MoveTowards (this.transform.position, target.position, step);  

	}

}
