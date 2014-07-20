using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {

	private AnimatedTextureExtendedUV animateTexture;

	enum ePlayerDir {stationary = 0, left, right, up, down};
	private ePlayerDir eMoving = ePlayerDir.stationary;

	// Use this for initialization
	void Start () 
	{
		animateTexture = gameObject.GetComponent<AnimatedTextureExtendedUV>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a") && eMoving != ePlayerDir.left)
		{
			eMoving = ePlayerDir.left;
			animateTexture.rowNumber = 1;
		}
		else if (Input.GetKey ("d") && eMoving != ePlayerDir.right)
		{
			eMoving = ePlayerDir.right;
			animateTexture.rowNumber = 2;
		}
		else if (Input.GetKey ("w") && eMoving != ePlayerDir.up)
		{
			eMoving = ePlayerDir.up;
			animateTexture.rowNumber = 3;
		}
		else if (!Input.GetKey ("a") && !Input.GetKey ("d") && eMoving != ePlayerDir.stationary)
		{
			eMoving = ePlayerDir.stationary;
			animateTexture.rowNumber = 0;
		}
	}
}
