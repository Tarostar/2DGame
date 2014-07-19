using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {

	private AnimatedTextureExtendedUV animateTexture;

	private bool bMoving = false;

	// Use this for initialization
	void Start () {
		animateTexture = gameObject.GetComponent<AnimatedTextureExtendedUV>();
		//control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey ("a") || Input.GetKey ("d")) && !bMoving)
		{
			bMoving = true;
			animateTexture.rowNumber = 1;
		}
		else if (!Input.GetKey ("a") && !Input.GetKey ("d") && bMoving)
		{
			bMoving = false;
			animateTexture.rowNumber = 0;
		}
	}
}
