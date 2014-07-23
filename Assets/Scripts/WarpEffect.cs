using UnityEngine;
using System.Collections;

public class WarpEffect : MonoBehaviour {

	private CharacterMotor characterMotor = null;

	private int effectDuration = 3;


	void OnCollisionEnter2D(Collision2D other)
	{
		print ("OnCollision");
	}

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other) 
	{
		print("bam");
		// create funny camera effect by removing lock and remembering in player prefs

		// freeze player
		characterMotor = GameObject.FindWithTag("Player").GetComponent<CharacterMotor>();
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
			characterMotor.canControl = false;

		yield return new WaitForSeconds(effectDuration);

		if (characterMotor != null)
			characterMotor.canControl = true;
	}
	

}
