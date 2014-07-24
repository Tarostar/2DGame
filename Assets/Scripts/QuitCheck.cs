using UnityEngine;
using System.Collections;

public class QuitCheck : MonoBehaviour 
{
	void Update () 
	{
		// quit
		if (Input.GetKey("escape") || Input.GetKey("q"))
		{
			ResetPlayerPrefs();
			Application.Quit();
		}

		// reset player prefs
		if (Input.GetKey("r"))
		{
			ResetPlayerPrefs();
		}
	}

	void ResetPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}
}
