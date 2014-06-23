using UnityEngine;
using System.Collections;

public class path : MonoBehaviour {

	public GameObject start;
	public EndPointScript end;
	protected GameGeneral game;
	public GameObject player;
	public bool started;
	public GameObject[] pickobject;
	public pickableObject treasure ; 
	private bool page1 = false; 
	private bool page2 = false; 
	public void setGameScript(GameGeneral g)
	{
		game = g;
	}

	void Awake() {
		Picktreasure (); 
		//Debug.Log (treasure.name); 

	}

	public void Picktreasure() {
		
		/*Which Object is the treasure */ 
		pickobject = GameObject.FindGameObjectsWithTag("pickable"); 
		if (pickobject.Length > 0) {
			foreach (GameObject obj in pickobject)
					obj.GetComponent<pickableObject> ().treasure = false; 

			int re = Random.Range (0, pickobject.Length);
			//Debug.Log(GameObject.FindGameObjectsWithTag("pickable").Length); 
			pickobject[re].GetComponent<pickableObject> ().treasure = true; 		
			treasure = pickobject[re].GetComponent<pickableObject>();   
			pickobject = null; 
				}


			
	}



}
