using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {

	private AnimatedTextureExtendedUV animateTexture;

	public AudioClip step;
	public AudioClip jump;

	enum ePlayerDir {stationary = 0, left, right, up, down};
	private ePlayerDir eMoving = ePlayerDir.stationary;

	// Use this for initialization
	void Start () 
	{
		animateTexture = gameObject.GetComponent<AnimatedTextureExtendedUV>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// jump sound
		if (Input.GetKeyDown ("space"))
		{
			if (audio.isPlaying)
				audio.Stop ();

			audio.clip = jump;
			audio.Play();
		}

		if ((Input.GetKey ("a") || Input.GetKey("left")) && eMoving != ePlayerDir.left)
		{
			/*if (!audio.isPlaying)
			{
				audio.clip = step;
				audio.Play();
			}*/

			eMoving = ePlayerDir.left;
			animateTexture.rowNumber = 1;
		}
		else if ((Input.GetKey ("d") || Input.GetKey("right")) && eMoving != ePlayerDir.right)
		{
			/*if (!audio.isPlaying)
			{
				audio.clip = step;
				audio.Play();
			}*/

			eMoving = ePlayerDir.right;
			animateTexture.rowNumber = 2;
		}
		else if ((Input.GetKey ("w") || Input.GetKey("up")) && eMoving != ePlayerDir.up)
		{
			eMoving = ePlayerDir.up;
			animateTexture.rowNumber = 3;
		}
		else if (!Input.GetKey ("a") &&  !Input.GetKey("left") &&
		         !Input.GetKey ("d") && !Input.GetKey("right") &&
		         !Input.GetKey ("w") && !Input.GetKey("up") &&
		         eMoving != ePlayerDir.stationary)
		{
			eMoving = ePlayerDir.stationary;
			animateTexture.rowNumber = 0;
		}
	}
}
