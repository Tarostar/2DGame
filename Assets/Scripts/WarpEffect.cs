using UnityEngine;
using System.Collections;

public class WarpEffect : MonoBehaviour {

	private PlatformerCharacter2D characterMotor = null;

	private int effectDuration = 3;

	// stop multiple triggers happening (possibly due to new 2D controller having 2 colliders...)
	bool bExited = true;

	int nCount = 0;

	void OnTriggerExit2D(Collider2D other) 
	{
		bExited = true;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (!bExited)
			return;

		bExited = false;

		// IMPORTANT: note if animator is in same object as collider for player then this will keep triggering

		nCount++;
		print ("triggered" + nCount);

		// create funny camera effect by removing lock and remembering in player prefs

		// freeze player
		characterMotor = GameObject.FindWithTag("Player").GetComponent<PlatformerCharacter2D>();
		if (!characterMotor)
		{
			print ("Error, cannot get character motor");
		}
		StartCoroutine (FreezeMovement());

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
			Destroy(effect, effectDuration);


			SmoothFollow2 smoothFollow = GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>();
			if (smoothFollow != null)
			{
				smoothFollow.lockRotation = true;
				PlayerPrefs.SetInt("Warped", 0);
			}

			/*Light light = GetComponent <Light>();
			light.enabled = true;*/
		}
		else
		{
			// warp effect
			audio.Play ();

			// create particle effect (and set it to self destruct)
			GameObject effect = Instantiate(Resources.Load("WarpParticles"), pos, Quaternion.identity) as GameObject;
			Destroy(effect, effectDuration);

			SmoothFollow2 smoothFollow = GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>();
			if (smoothFollow != null)
			{
				smoothFollow.lockRotation = false;
				PlayerPrefs.SetInt("Warped", 1);
			}

			/*Light light = GetComponent <Light>();
			light.enabled = true;*/
		}
	}

	IEnumerator FreezeMovement()
	{
		if (characterMotor != null)
			characterMotor.canMove = false;

		yield return new WaitForSeconds(effectDuration);

		if (characterMotor != null)
			characterMotor.canMove = true;
	}
	

}
