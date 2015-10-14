using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour {
	static ShowFPS _showFPS = null;
	public ShowFPS _ShowFPS{
			get{ return _showFPS; }
	}

	public float        updateInterval = 0.5f;	//fps update time

	float	accum = 0.0f;           // fps
	float	timeLeft = 0.0f;        // now update time
	int		frames = 0;             // frame
	bool	isShowFPS = false;


	// Use this for initialization
	public static void Show () {
		ShowFPS._showFPS.timeLeft = ShowFPS._showFPS.updateInterval;
		ShowFPS._showFPS.isShowFPS = true;
	}


	// Update is called once per frame
	void Update () {
		if(isShowFPS){
			timeLeft -= Time.deltaTime;
			accum += (Time.timeScale / Time.deltaTime);
			++frames;
			if ( timeLeft <= 0.0f ) 
			{
				float fps = accum / frames; 
				float timePerFrame = 1000.0f / fps; 

				guiText.text = "timePerFrame: " + timePerFrame.ToString("f2") + "ms\n";
				guiText.text += "framePerSecond: " + fps.ToString("f2");

				timeLeft = updateInterval;
				accum = 0.0f;
				frames = 0;
			}
		}
	}
}
