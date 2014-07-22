using UnityEngine;
using System.Collections;

public class WarpCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int nWarped = PlayerPrefs.GetInt("Warped");
		if (nWarped == 1)
		{
			GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>().lockRotation = false;
		}
		

	}
}
