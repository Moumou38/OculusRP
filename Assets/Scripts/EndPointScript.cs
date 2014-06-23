using UnityEngine;
using System.Collections;

public class EndPointScript : MonoBehaviour {
	
	
	private GameGeneral mainScript;
	public GameObject GGS; 
	private bool collided;
	// Use this for initialization
	void Awake() {
		enabled = true;
		collided = false;
	}

	void Start () {
		GGS = GameObject.Find ("GameGeneralScript"); 
		mainScript = GGS.GetComponent<GameGeneral> (); 

	}
	
	// Update is called once per frame
    void Update()
    {
        if (collided)
        {
			if (Input.GetKeyDown(KeyCode.E) && Raycast.pickedUpObject != null && Raycast.pickedUpObject.GetComponent<pickableObject>().treasure == true) 
			{
				Raycast.Drop(); 
				mainScript.EndGame(); 
			
			}
				
        }
    }
	
	void OnTriggerEnter(Collider p) {
		collided = true; 
        
	}
	
	void OnTriggerExit(Collider player) {
		collided = false; 

    }
}
