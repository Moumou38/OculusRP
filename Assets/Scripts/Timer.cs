using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    private float angle;
    public float min = 0, max = 3*60;
    private RealTimer time = new RealTimer();
	private Vector2 pos = new Vector2 (-Screen.width / 2 + 30, Screen.height / 2 - 20 ) ; 
	public bool end = false; 
	private string tmp = ""; 
	// Use this for initialization
	void Awake () {
        time.Pause();
	}
	
	// Update is called once per frame
	void Update () {

        if (time.IsPaused())
        {
            return;
        }
        TimeSpan left = time.TimeLeft();

		//Debug.Log (left);

		 tmp = left.Minutes + " : " + left.Seconds; 
		 

		if (left.Seconds < 0)
						end = true; 

	}

    public void SetTime(int t)
    {
        time.delay = t;
        time.Start();
    }

	public TimeSpan left() {
				return time.TimeLeft ();
		}

    public void Pause()
    {
        time.Pause();
    }

    public void Resume()
    {
        time.Resume();
    }

    public void Start()
    {
        Debug.Log("timer start");
        time.Start();
    }

    public bool IsPaused()
    {
        return time.IsPaused();
    }


}
