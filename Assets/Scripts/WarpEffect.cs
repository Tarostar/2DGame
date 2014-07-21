using UnityEngine;
using System.Collections;

public class WarpEffect : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter () 
	{
		// create funny camera effect by removing lock and remembering in player prefs

		// set position slightly above warper and in front of player
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 2, -5.0f);

		// check if effect already set, and if so set back to normal
		int nWarped = PlayerPrefs.GetInt("Warped");
		if (nWarped == 1)
		{
			// return to normal
			audio.Play ();

			// create particle effect (and set it to self destruct)
			GameObject effect = Instantiate(Resources.Load("WarpBack"), pos, Quaternion.identity) as GameObject;
			Destroy(effect, 5);


			SmoothFollow2 smoothFollow = GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>();
			smoothFollow.lockRotation = true;
			PlayerPrefs.SetInt("Warped", 0);
		}
		else
		{
			// warp effect
			audio.Play ();

			// create particle effect (and set it to self destruct)
			GameObject effect = Instantiate(Resources.Load("WarpParticles"), pos, Quaternion.identity) as GameObject;
			Destroy(effect, 5);

			SmoothFollow2 smoothFollow = GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>();
			smoothFollow.lockRotation = false;
			PlayerPrefs.SetInt("Warped", 1);
		}


	}
	

}
