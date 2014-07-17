using UnityEngine;
using System.Collections;

public class TextureFlip : MonoBehaviour 
{
	Vector3 v3Texture;

	bool bLeft = true;

	// Use this for initialization
	void Start () 
	{
		// normal object scale
		v3Texture = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// go left
		if (Input.GetKey ("d") && !bLeft)
		{
			// flip texture
			bLeft = true;
			transform.localScale = new Vector3(v3Texture.x, v3Texture.y, v3Texture.z);;
		}

		// go right
		if (Input.GetKey ("a") && bLeft)
		{
			// set texture to normal position
			bLeft = false;
			transform.localScale = new Vector3(-v3Texture.x, v3Texture.y, v3Texture.z);;
		}
	
	}
}
