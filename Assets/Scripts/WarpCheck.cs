using UnityEngine;
using System.Collections;

public class WarpCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SmoothFollow2 smoothFollow = GameObject.FindWithTag("MainCamera").GetComponent<SmoothFollow2>();

		int nWarped = PlayerPrefs.GetInt("Warped");
		if (nWarped == 1)
			smoothFollow.lockRotation = false;
		

	}
}
