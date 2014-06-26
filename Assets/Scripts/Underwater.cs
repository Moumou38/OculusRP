using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {
	
	//This script enables underwater effects. Attach to main camera.
	
	//Define variable
	private float underwaterLevel ;
	
	//The scene's default fog settings
	private bool defaultFog ;
	private Color defaultFogColor ;
	private float defaultFogDensity ;
	private float timer; 

	
	void Start () {
		//Define variable
		underwaterLevel = -53.15f;
		
		//The scene's default fog settings
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		//Set the background color
		camera.backgroundColor = new Color(0, 0.4f, 0.7f, 1);
		timer = 0f; 
	}
	
	void Update () {
		if (transform.position.y < underwaterLevel)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color(0.4f, 0.6f, 0.5f, 0.3f);
			RenderSettings.fogDensity = 0.08f; 
			timer += Time.deltaTime ;

			if(timer > 1) {Player.health -= 1; timer = 0f; }



		}
		else
		{
			RenderSettings.fog = false;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogDensity = defaultFogDensity;
			timer = 0f; 
		}
	}
}