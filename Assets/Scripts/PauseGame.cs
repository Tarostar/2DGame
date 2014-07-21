using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	private float timeScale;
	private bool paused = false;
	public float pauseSpeed = 0.005f;

	// Use this for initialization
	void Start () 
	{
		timeScale = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (Input.GetKeyDown ("p"))
		{
			if (!paused)
				paused = true;
			else
				paused = false;
		}

		if (paused)
		{
			if (Time.timeScale > 0.0f)
			{
				if (Time.timeScale - pauseSpeed <= 0.0f)
				{
					Time.timeScale = 0.0f;
				}
				else
				{
					Time.timeScale -= pauseSpeed;
				}

			}

			if (audio.isPlaying)
			{
				print ("Audio pause: " + audio.pitch);
				if (audio.pitch > 0.0f)
				{
					if (Time.timeScale - pauseSpeed <= 0.0f)
						audio.pitch = 0.0f;
					else
						audio.pitch -= pauseSpeed;
				}
				else
				{
					audio.Pause ();
				}
			}
		}
		else
		{
			if (Time.timeScale < timeScale)
			{
				if (Time.timeScale - pauseSpeed > timeScale)
					Time.timeScale = timeScale;
				else
					Time.timeScale += pauseSpeed;
				
			}
			
			if (!audio.isPlaying)
			{
				print ("Play audio");
				audio.Play();
			}
			else if (audio.pitch < 1.0f)
			{
				print ("Audio speedup: " + audio.pitch);
				audio.pitch += pauseSpeed;
			}
		}
	}
}
