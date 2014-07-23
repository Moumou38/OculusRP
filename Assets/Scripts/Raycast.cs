using UnityEngine;
using System.Collections;

public class Raycast : VRGUI 
{
	private Ray ray; 
	private RaycastHit hit; 
	private bool pickable = false; 
	private float limGrab = 25f * 0.1f;
	private Vector3 pos ; 
	public Texture reticle;
	public Texture hand;
	public static GameObject pickedUpObject = null; 
	private static bool picked = false; 
	private Transform cameraTransform; 
	public GUISkin skin;
	void Start()
	{
		cameraTransform = GameObject.FindWithTag("MainCamera").transform; 

	}
	
	void Update()
	{

		Vector3 rayDirection = cameraTransform.TransformDirection(Vector3.forward);
		Vector3 rayStart = cameraTransform.position + rayDirection; 
		//ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); 
		if (Physics.Raycast (rayStart, rayDirection, out hit)) {
			Debug.DrawLine (transform.position, hit.point, Color.red);
			//Debug.Log(hit.transform.tag); 
			if(hit.transform.tag == "pickable" && hit.distance < limGrab){
				pickable = true; 
				if(Input.GetKeyDown("e") && pickedUpObject == null){PickUp(); }

			}
			else pickable = false; 


				
		}
		if(Input.GetKeyDown("a") && pickedUpObject != null) { Drop (); 	}

			
			
		}
	public override void OnVRGUI() {

		GUI.skin = skin; 

		if (!Tutorial.tuto) {
			if (picked) {
				GUI.DrawTexture (new Rect (Screen.width / 2 - (hand.width * 0.5f), Screen.height / 2 - (hand.height * 0.5f), hand.width, hand.height), hand); //display a hand if we can carry object	
				
			} 
			else {
				if (pickable) { 
					GUI.DrawTexture(new Rect(Screen.width / 2 - (hand.width * 0.5f), Screen.height / 2 - (hand.height * 0.5f), hand.width, hand.height), hand); //display a hand if we can carry object
				}
				else GUI.DrawTexture(new Rect(Screen.width / 2 - (reticle.width * 0.5f), Screen.height / 2 - (reticle.height * 0.5f), reticle.width, reticle.height), reticle); //display reticle if object non pickable				
				
			}		
		
		
		
		
		}



	}

	public static void Drop(){
		picked = false; 
		pickedUpObject.GetComponent<Rigidbody>().isKinematic = false; 
		pickedUpObject.transform.parent = GameGeneral.currentPath.transform; 
		pickedUpObject = null; 

	}

	public void PickUp(){
		picked = true; 
		pickedUpObject=hit.transform.gameObject; 
		pickedUpObject.transform.parent=transform.parent; 
		pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
		pos = transform.parent.forward.normalized ;  
		pos.y -= 0.15f; 
		pos.x += 0.25f; 
		pickedUpObject.transform.position=transform.position+pos; 
	}


	}