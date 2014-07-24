using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	private Light lightclaveau;
	private float intensity ;
	private int up;
	private float timer; 
	// Use this for initialization
	void Start () {
		intensity = 0.7f ;
		lightclaveau = this.light; 
		up = 1 ;
		timer = 0f; 
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0.02f)
		{
			intensity += up * 0.10f *0.1f;
			lightclaveau.intensity = intensity;
			if (intensity > 4 * 0.3f) up = -1;
			else if (intensity < 3 * 0.3f) up = 1;
		}

		//Debug.Log (intensity); 
		
		
		timer += Time.deltaTime;
		
		
		
	}
}
